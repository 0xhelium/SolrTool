using Ionic.Zip;
using Renci.SshNet;
using SolrTool.Models;
using SolrTool.Models.SolrModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SolrTool
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            Init();
            logger.Log("application start up.");

            BindEvents();

            timer.Start();
        }

        private Logger logger;
        private ScrollLog scrollLog;
        private Timer timer ;


        private bool _timerExec = false;


        private void Init()
        {
            logger = Logger.Create(LogType.INFO);
            scrollLog = ScrollLog.Create(logger.LogPath);
            timer = new Timer();
            timer.Interval = 10;


            this.StartPosition = FormStartPosition.CenterScreen;
            ComboSolrCore.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboSolrCollection.DropDownStyle = ComboBoxStyle.DropDownList;

            TextBoxLog.ForeColor = System.Drawing.ColorTranslator.FromHtml("#00ff07");

            imageList = new ImageList();
            imageList.Images.Add("folder", Resource.folder);
            imageList.Images.Add("folder-close", Resource.folderclosed);
            imageList.Images.Add("file", Resource.file);

            tree.ImageList = imageList;
        }

        private void BindEvents()
        {
            Load += async (s, e) =>
            {

                StatusStripLabel.Text = "checking configs...";
                logger.Log("starting to CheckConfigs");
                await CheckConfigs();
                logger.Log("CheckConfigs finished");

                StatusStripLabel.Text = "load solr infomation...";
                await LoadSolrInfo();
                StatusStripLabel.Text = "finished";
            };

            FormClosed += (s, e) =>
            {
                logger.Log("application exit.");
                logger.Dispose();
            };

            timer.Tick += (s, e) =>
            {
                if (_timerExec)
                {
                    return;
                }

                _timerExec = true;
                var logs = logger.GetBufferLog();

                Action act = () =>
                {
                    AppendLog(logs);
                    TextBoxLog.Select(TextBoxLog.TextLength, 0);
                    TextBoxLog.ScrollToCaret();
                };

                if (logs.Length > 0)
                {
                    this.Invoke(act);
                }

                _timerExec = false;
            };

            ComboSolrCollection.SelectedIndexChanged += async (s, e) =>
            {
                var col = ComboSolrCollection.Items[ComboSolrCollection.SelectedIndex].ToString();
                var files = await SolrHttpOperation.GetFiles(col);
                var dirs = files.Lst.FirstOrDefault(x => x.Name == "files").Lsts
                            .Where(x => x.Bool != null && x.Bool.Count > 0 && x.Bool.FirstOrDefault().Name == "directory")
                            .Select(x => x.Name);

                if (files.Lst.FirstOrDefault(x => x.Name == "files") != null)
                {
                    await GenTree(tree.Nodes, col);
                }
            };

            tree.AfterSelect += async (sender, treeArgs) =>
            {
                var selectedNode = treeArgs.Node;
                var selectedNodeText = selectedNode.FullPath;

                if (selectedNode.Tag.ToString() == "d")
                {
                    await GenTree(selectedNode.Nodes, ComboSolrCollection.Items[ComboSolrCollection.SelectedIndex].ToString(), selectedNodeText);
                }
                if (selectedNode.Tag.ToString() == "f")
                {
                    var content = await SolrHttpOperation.GetFileContent(ComboSolrCollection.Items[ComboSolrCollection.SelectedIndex].ToString(), selectedNodeText);

                    TextBoxFileContent.Text = content;
                    TextBoxFileContent.Tag = $"{ComboSolrCollection.Items[ComboSolrCollection.SelectedIndex].ToString()}/{ selectedNode.FullPath.Replace("\\", "/")}";
                }
            };

            tree.AfterExpand += async (s, e) =>
            {
                if (tree.SelectedNode != e.Node)
                {
                    tree.SelectedNode = e.Node;
                }
            };

            LinkLblCopy.Click += async (s, e) =>
            {
                Clipboard.SetText(TextBoxFileContent.Text);
                LinkLblCopy.Text = "复制成功";
                await Task.Delay(2000);
                LinkLblCopy.Text = "COPY";
            };

            //导出
            BtnExportAllFiles.Click += async (s, e) =>
            {
                BtnExportAllFiles.Enabled = false;
                var path = await ExportAllFiles(ComboSolrCollection.Items[ComboSolrCollection.SelectedIndex].ToString());
                BtnExportAllFiles.Enabled = true;

                var psi = new ProcessStartInfo("cmd.exe", $"/c \"explorer.exe {path}\"");
                psi.CreateNoWindow = true;
                Process.Start(psi);
            };

            BtnExportAllCollections.Click += async (s, e) =>
            {
                BtnExportAllCollections.Enabled = false;

                var path = "";
                ComboSolrCollection.SelectedIndex = 0;
                foreach (var item in ComboSolrCollection.Items)
                {
                    path = await ExportAllFiles(item.ToString());
                }
                var configPath = new DirectoryInfo(path).Parent.FullName;

                BtnExportAllCollections.Enabled = true;

                var psi = new ProcessStartInfo("cmd.exe", $"/c \"explorer.exe {configPath}\"");
                psi.CreateNoWindow = true;
                Process.Start(psi);
            };

            //文件更新
            BtnUpdateCurrentFile.Click += async (s, e) =>
            {

                var path = TextBoxFileContent.Tag?.ToString();
                if (string.IsNullOrWhiteSpace(path))
                {
                    MessageBox.Show("please select a node for update.");
                    return;
                }

                var dr = MessageBox.Show($"将更新文件:[{path}], 是否继续?", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    BtnUpdateCurrentFile.Enabled = false;
                    StatusStripLabel.Text = "updateing config...";

                    await UpdateCurrentFile(path);

                    StatusStripLabel.Text = "finished";
                    BtnUpdateCurrentFile.Enabled = true;
                    MessageBox.Show("更新成功");
                }
            };

            //重载
            BtnReoload.Click += async (s, e) =>
            {
                BtnReoload.Enabled = false;
                await LoadSolrInfo();
                BtnReoload.Enabled = true;
            };

            //创建配置
            BtnUploadConfig.Click += async (s, e) =>
            {
                BtnUploadConfig.Enabled = false;
                string confName = "", confFolder = "";
                var frm = new FrmConfigUploadBox();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.FormClosing += (sender, args) =>
                {
                    confFolder = frm.ConfigFolder;
                    confName = frm.ConfigName;
                };
                frm.ShowDialog(this);
                if (confName != "" && confFolder != "")
                {
                    var client = SolrHttpClient.Create(
                        AppGlobalConfigs.AppConfig.Solr.BaseUrl,
                        AppGlobalConfigs.AppConfig.Solr.Auth.Username,
                        AppGlobalConfigs.AppConfig.Solr.Auth.Password
                    );

                    if (Directory.Exists(confFolder))
                    {
                        var tmpDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tmp");
                        if (!Directory.Exists(tmpDir))
                        {
                            Directory.CreateDirectory(tmpDir);
                        }

                        var file = Path.Combine(tmpDir, Guid.NewGuid().ToString("N") + ".zip");
                        using (var zip = new ZipFile())
                        {
                            zip.AddDirectory(confFolder);
                            zip.Save(file);
                        }
                        await SolrHttpOperation.CreateConfig(confName, file);
                    }
                }

                BtnUploadConfig.Enabled = true;
            };
        }

        private async Task GenTree(TreeNodeCollection target, string indexName, string folderName="")
        {
            SolrFile files;
            if (string.IsNullOrWhiteSpace(folderName))
            {
                files = await SolrHttpOperation.GetFiles(indexName);
            }
            else
            {
                files = await SolrHttpOperation.GetDirFiles(indexName, folderName);
            }

            var dirs = files.Lst.FirstOrDefault(x => x.Name == "files").Lsts
                            .Where(x => x.Bool != null && x.Bool.Count > 0 && x.Bool.FirstOrDefault().Name == "directory")
                            .Select(x => x.Name);

            var nodes = files.Lst.FirstOrDefault(x => x.Name == "files").Lsts.Select(x =>
            {
                var node = new TreeNode
                {
                    Text = x.Name,
                    Tag = "f",
                    ImageKey = "file",
                    SelectedImageKey = "file",     
                };

                if (dirs.Contains(x.Name))
                {
                    node.Tag = "d";
                    node.ImageKey = "folder-close";
                    node.SelectedImageKey = "folder";
                    node.Nodes.Add("");
                }

                return node;
            }).ToArray();

            target.Clear();
            target.AddRange(nodes);
            
            tree.ExpandAll();
        }


        private void AppendLog(string logs)
        {
            if (TextBoxLog.Text.Length > 20000)
            {
                TextBoxLog.Text = TextBoxLog.Text.Substring(10000);
            }

            TextBoxLog.AppendText(Environment.NewLine + logs);
        }

        private async Task LoadSolrInfo()
        {
            logger.Log("starting to get solr cores");
            var cores = await SolrHttpOperation.GetCores();
            ComboSolrCore.Items.Clear();
            ComboSolrCore.Items.AddRange(cores.Lst.FirstOrDefault(x => x.Name == "status").Lsts.Select(x => x.Name).OrderBy(x => x).ToArray());
            logger.Log("get solr cores finished");

            if (AppGlobalConfigs.AppConfig.Solr.SingleNode != "1")
            {
                logger.Log("starting to get solr collection");
                lblSolrCollection.Show();
                ComboSolrCollection.Show();
                var collctions = await SolrHttpOperation.GetCollection();
                ComboSolrCollection.Items.Clear();
                ComboSolrCollection.Items.AddRange(collctions.Arr.Str.Select(x => x).OrderBy(x => x).ToArray());
                logger.Log("get solr collection finished");
            }            
        }

        private Task CheckConfigs()
        {
            if (!File.Exists(AppGlobalConfigs.ConfigFilePath))
            {
                var xmlSerializer = new XmlSerializer(typeof(ConfigRoot), new XmlAttributeOverrides());
                using (var stringWriter = new StringWriter())
                using (var writer = XmlWriter.Create(stringWriter, new XmlWriterSettings()
                {
                    Indent = true,
                    Encoding = Encoding.UTF8,
                }))
                {
                    xmlSerializer.Serialize(writer,
                        new ConfigRoot
                        {
                            Server=new _Server { Addr=new _Addr { Ip="",Port=""},Auth=new _Auth { } },
                            Solr = new _Solr { Auth = new _Auth { }, BaseUrl = "" },
                            Zookeeper = new _Zookeeper { BinPath = "" },
                        });
                    var xmlString = stringWriter.ToString();
                    File.WriteAllText(AppGlobalConfigs.ConfigFilePath, xmlString);
                }
            }

            //if (string.IsNullOrWhiteSpace(AppConfig.Solr.BaseUrl))
            //{
            //    var dr = MessageBox.Show("未配置solr连接信息, 是否立即配置?", "提示", MessageBoxButtons.OKCancel);
            //    if (dr == DialogResult.OK)
            //    {
            //        Process.Start("notepad.exe", $"\"{ConfigFilePath}\"");
            //    }
            //}

            return Task.Delay(0);
        }

        //tests
        private void button1_Click(object sender, EventArgs e)
        {
            var pci = new PasswordConnectionInfo("192.168.253.131", "root", "123123");
            using (var sshClient = new SshClient(pci))
            {
                sshClient.Connect();

                sshClient.RunCommand("echo helloworld > /root/hello.txt");


                sshClient.Disconnect();
            }
        }


        private async Task<string> ExportAllFiles(string indexName)
        {
            StatusStripLabel.Text = "Export Files...";
            var tmp = System.Environment.GetEnvironmentVariable("TEMP") ?? "";
            logger.Log("get system tempory folder");
            logger.Log($"tempory folder:{tmp}");
            var exportPath = Path.Combine(tmp.Length > 0 ? tmp : AppGlobalConfigs.BaseDirectory, "export", "configs", indexName);
            logger.Log($"export path folder:{exportPath}");
            if (!Directory.Exists(exportPath))
            {
                Directory.CreateDirectory(exportPath);
            }

            await GetAllNodes(tree.Nodes, exportPath);

            StatusStripLabel.Text = "finished";
            return exportPath;
        }

        private async Task GetAllNodes(TreeNodeCollection nodes,string folder)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag + "" == "f")
                {
                    var content = await SolrHttpOperation.GetFileContent(ComboSolrCollection.Items[ComboSolrCollection.SelectedIndex].ToString(), node.FullPath);
                    var filename = Path.Combine(folder, node.FullPath);
                    var fileinfo = new FileInfo(filename);
                    if (!Directory.Exists(fileinfo.DirectoryName))
                    {
                        Directory.CreateDirectory(fileinfo.DirectoryName);
                    }

                    File.WriteAllText(filename, content);
                }
                else
                {
                    await GetAllNodes(node.Nodes, folder);
                }
            }
        }

        private async Task UpdateCurrentFile(string path)
        {
            logger.Log("preparing commands...");

            var content = TextBoxFileContent.Text.Replace("'", "'\\''").Replace("\r", "");
            var lines = content.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).Where(x => x.Trim().Length > 0 && x.Trim() != "\n").Select(x => x);
            content = string.Join("\n", lines);
            var cmd = $"{AppGlobalConfigs.AppConfig.Zookeeper.BinPath}zkCli.sh " +
                $"-server {AppGlobalConfigs.AppConfig.Server.Addr.Ip}:{AppGlobalConfigs.AppConfig.Zookeeper.CliPort} " +
                $"set {AppGlobalConfigs.AppConfig.Zookeeper.ConfigPath}{path} '{content}'";
            
            var pci = new PasswordConnectionInfo(
                AppGlobalConfigs.AppConfig.Server.Addr.Ip,
                AppGlobalConfigs.AppConfig.Server.Auth.Username,
                AppGlobalConfigs.AppConfig.Server.Auth.Password);

            await Task.Run(() =>
            {
                using (var sshClient = new SshClient(pci))
                {
                    logger.Log("connecting to server...");
                    sshClient.Connect();
                    logger.Log("server connected.");
                    logger.Log("executing commands:" + cmd);
                    var sshCmd = sshClient.RunCommand(cmd);

                    logger.Log($"execute result:[{sshCmd.Result}]");

                    logger.Log("executing commands complete.");
                    sshClient.Disconnect();
                    logger.Log("server disconnected.");
                }
            });
        }
    }
}
