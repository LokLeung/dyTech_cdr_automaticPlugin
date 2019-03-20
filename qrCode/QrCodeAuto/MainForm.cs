using QRCoder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using corel = Corel.Interop.VGCore;
using Shape = Corel.Interop.VGCore.Shape;
using ShapeRange = Corel.Interop.VGCore.ShapeRange;
using Shapes = Corel.Interop.VGCore.Shapes;

namespace QrCodeAuto
{
    public partial class MainForm : Form
    {
        private corel.Application corelApp;
        private ArrayList datas;
        private int qrX;
        private int qrY;

        public MainForm(corel.Application app)
        {
            this.corelApp = app;
            datas = new ArrayList();
            InitializeComponent();
        }

        //加快处理速度
        private void myOptimize(Boolean use, Boolean isStart = true)
        {
            if (use)
            {
                if (isStart)
                {
                    corelApp.Optimization = true;
                    corelApp.EventsEnabled = false;
                    corelApp.ActiveDocument.SaveSettings();
                    corelApp.ActiveDocument.PreserveSelection = false;
                }
                else
                {
                    corelApp.ActiveDocument.PreserveSelection = true;
                    corelApp.ActiveDocument.RestoreSettings();
                    corelApp.Optimization = false;
                    corelApp.EventsEnabled = true;
                    corelApp.ActiveWindow.Refresh();
                }
            }
        }

        //加载表格数据    街路巷|地址名称|二维码文本
        private void button_loadTable_Click(object sender, EventArgs e)
        {
            String dataPath = "";
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = "C:\\Users\\10347\\Desktop\\伟圣门牌插件";    //打开对话框后的初始目录
            fileDialog.Filter = "表格文件|*.csv";
            fileDialog.RestoreDirectory = false;    //若为false，则打开对话框后为上次的目录。若为true，则为初始目录
            if (fileDialog.ShowDialog() == DialogResult.OK)
                dataPath = System.IO.Path.GetFullPath(fileDialog.FileName);
            
            if (dataPath != "")
            {
                FileStream fs = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.None);

                if (fs != null)
                {
                    StreamReader sr = new StreamReader(fs, System.Text.Encoding.GetEncoding(936));
                    string str = "";
                    while (str != null)
                    {
                        str = sr.ReadLine();//读取一行
                        if (str == null) break;//读完了就跳出循环

                        String[] eachLine = new String[3];//因为知道每一行excel有2个单元格，所以string[2]
                        eachLine = str.Split(',');//因为.csv文件是以逗号分隔单元格里数据的，所以调用分隔函数split
                        if (eachLine.Length == 3)
                        {
                            datas.Add(eachLine);
                        }
                        else
                            MessageBox.Show("读取数据中二维码列有问题，可能导致不能正常读取二维码");
                    }
                    datas.RemoveAt(0);
                    sr.Close();
                }

                label_LoadedCount.Text = "加载数据:" + datas.Count.ToString();
            }
            
            foreach (string[] data in datas)
            {
                //if (!data[2].Contains("号"))
                //    data[2] = data[2] + "号";
                //string[] dirs1 = getFile(imgPath, data[2] + "(左");
                //string[] dirs2 = getFile(imgPath, data[2] + "(右");

                ////the path is good, add to the dict
                //if (dirs1.Length == 1 && dirs2.Length == 1)
                //{
                //    string[] key = new string[2];
                //    key[0] = dirs1[0]; key[1] = dirs2[0];
                //    dict_qrPath[data[2]] = key;
                //}
                //else
                //    rTB_info.AppendText("读取照片路径发生错误：" + data[2]);
                //qrcount++;
            }
        }

        //二维码文本 -> 二维码图片
        private void getQRCodeImg(string qrCodeText,int pixelPerModel,string imgPath)
        {
            //QRCodeData qRCodeData = ;
            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            QRCode qrCode = new QRCode(qRCodeGenerator.CreateQrCode(qrCodeText, QRCodeGenerator.ECCLevel.M));
            //Bitmap qrCodeImg = qrCode.GetGraphic(pixelPerModel);
            qrCode.GetGraphic(pixelPerModel,Color.Black,Color.White,false).Save(imgPath);
            //qrCodeImg.Save(imgPath);

            qRCodeGenerator.Dispose();
            qrCode.Dispose();
        }

        delegate void refreshUI(string text);
        private void setLabelValue(string text)
        {
            if (this.label5.InvokeRequired)
            {
                refreshUI r = new refreshUI(setLabelValue);
                this.Invoke(r, new object[] { text });
            }
            else
            {
                this.label5.Text = text;
            }
        }

        private void qrGenThread()
        {
            int count = 0;
            foreach (string[] data in datas)
            {
                getQRCodeImg(data[2], 20, dir + data[1] + ".jpg");
                count++;
                setLabelValue("生成二维码:" + count.ToString()+"/"+datas.Count.ToString());
                //label5.Text = "生成二维码:" + count.ToString();
            }
        }

        string dir = "C:\\Users\\10347\\Desktop\\伟圣门牌插件\\qrCodeImgs1\\";

        //开始批量生成
        private void button_start_Click(object sender, EventArgs e)
        {
            //获取当前文件夹路径
            if (false == System.IO.Directory.Exists(dir))
            {
                //创建pic文件夹
                System.IO.Directory.CreateDirectory(dir);
            }
            Thread thread = new Thread(new ThreadStart(qrGenThread));
            thread.Start();
            //foreach (string[] data in datas)
            //{
            //    //getQRCodeImg(data[2], 20, dir + data[1] + ".jpg");
            //}
        }

        //开始导入排版
        private void button_startRun_Click(object sender, EventArgs e)
        {
            //for(int i = 1; i < 21; i++)
            //{
            //    string[] data = (string[])datas[i];
            //    int padding = 3;
            //    var sh_qrcode = myQrcode(dir + data[1] + ".jpg", 20 ,i * (20+padding), 0);
            //    //文字
            //    corelApp.ActiveLayer.CreateArtisticText(sh_qrcode.LeftX,sh_qrcode.TopY, data[1],Size:150);
            //}

            myOptimize(true, true);
            int count = 0;
            for (int x = 0; x < qrX; x++)
            {
                for(int y = 0; y < qrY; y++)
                {
                    string[] data = (string[])datas[count];
                    int Xpadding = (int)numericUpDown3.Value;
                    int Ypadding = (int)numericUpDown4.Value;
                    int size = (int)numericUpDown5.Value;
                    var sh_qrcode = myQrcode(dir + data[1] + ".jpg", size);
                    //文字
                    Shape text = corelApp.ActiveLayer.CreateArtisticText(sh_qrcode.CenterX, sh_qrcode.BottomY, data[1], Size: 5*size);
                    sh_qrcode.SetPosition(x * (size + Xpadding), y * (size + text.SizeHeight + Ypadding));
                    text.CenterX = sh_qrcode.CenterX;
                    text.TopY = sh_qrcode.BottomY-text.SizeHeight*2/3;
                    count++;
                }
            }
            myOptimize(true, false);
        }

        //make a qrcode
        private Shape myQrcode(string imgpath,int size)
        {
            corelApp.ActiveLayer.Import(imgpath);
            corel.Shape bm_qrcode = corelApp.ActiveShape;
            //corel.ShapeRange sr_qrcode = bm_qrcode.Bitmap.Trace(corel.cdrTraceType.cdrTraceLineArt, 25, 100, DeleteOriginalObject: true, ColorCount: 2, ColorMode: corel.cdrColorType.cdrColorBlackAndWhite, RemoveBackground: false).Finish();

            //sr_qrcode.Group();
            bm_qrcode.SetSize(size, size);

            return bm_qrcode;
        }

        //行
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            qrX = (int)numericUpDown1.Value;
        }

        //列
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            qrY = (int)numericUpDown2.Value;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
