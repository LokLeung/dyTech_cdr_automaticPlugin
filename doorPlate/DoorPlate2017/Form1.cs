using ExcelDataReader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using corel = Corel.Interop.VGCore;
using Shape = Corel.Interop.VGCore.Shape;
using ShapeRange = Corel.Interop.VGCore.ShapeRange;
using Shapes = Corel.Interop.VGCore.Shapes;

namespace DoorPlate2017
{
    public partial class Form1 : Form
    {
        private corel.Application corelApp;
        //doorplate data
        ArrayList datas;
        ArrayList templates;
        ArrayList testList;
        Dictionary<string, string[]> dict_qrPath = new Dictionary<string, string[]>();
        int list_index = 1;
        string imgPath = "C:\\Users\\10347\\Desktop\\cdr\\昌平门牌号二维码";

        public Form1(corel.Application app)
        {
            this.corelApp = app;
            InitializeComponent();
            datas = new ArrayList();
            templates = new ArrayList();
            testList = new ArrayList();
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

        //get files
        private static string[] getFile(string path, string Name)
        {
            Directory.GetFiles(path);
            try
            {
                string[] dirs = Directory.GetFiles(path,"*" + Name + "*",SearchOption.AllDirectories);
                return dirs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //make a qrcode
        private void myQrcode(string name, corel.Shape sh_qrcode, string imgpath)
        {
            corelApp.ActiveLayer.Import(imgpath);
            corel.Shape bm_qrcode = corelApp.ActiveShape;
            corel.ShapeRange sr_qrcode = bm_qrcode.Bitmap.Trace(corel.cdrTraceType.cdrTraceLineArt,25,100,DeleteOriginalObject:true,ColorCount:2,ColorMode:corel.cdrColorType.cdrColorBlackAndWhite,RemoveBackground:false).Finish();

            //sr_qrcode.Group();
            sr_qrcode.SetSize(sh_qrcode.SizeWidth, sh_qrcode.SizeHeight);
            sr_qrcode.SetPosition(sh_qrcode.PositionX, sh_qrcode.PositionY);
        }

        //generate a lot of plates
        private void button1_Click(object sender, EventArgs e)
        {
            myOptimize(true, true);
            corel.Shapes shapes = corelApp.ActiveSelection.Shapes;//get selected shapes
            corel.Shape plate = shapes.FindShape("plate");
            corel.ShapeRange shapeRange = shapes.All();// used for clone
            MessageBox.Show(shapeRange.Count.ToString());
            double dx = plate.RightX - plate.LeftX;
            double dy = plate.TopY - plate.BottomY;

            int count = 1;
            for (int x = 1; x < 3; x++)
                for (int y = 1; y < 3; y++)
                {
                    string[] data = (string[])datas[count];
                    corel.ShapeRange sr = shapeRange.Clone(x * dx, y * dy);
                    corel.Shapes shs = sr.Shapes;
                    corel.Text sh_platename = shs.FindShape("H_第1列").Text;
                    corel.Text sh_platenum = shs.FindShape("H_第2列").Text;
                    if (sh_platename.IsArtisticText)
                    {
                        //sh_platename.Replace("大氹村前街十二巷", "我卢本伟没有开挂", false, ReplaceAll: true);
                        sh_platename.Story.Text = data[0];
                    }
                    if (sh_platenum.IsArtisticText)
                    {
                        //String num = count.ToString();
                        //sh_platenum.Replace("1", num, false, ReplaceAll: true);
                        sh_platenum.Story.Text = data[1];
                    }
                    count++;
                }
            myOptimize(true, false);
        }

        //test buttom
        private void button3_Click(object sender, EventArgs e)
        {
            int pageNum = 3;
            corel.ShapeRange sr_template = (corel.ShapeRange)templates[0];
            corel.Shape sh_template = sr_template.Shapes.FindShape("plate");
            double dx = sh_template.SizeWidth;
            double dy = sh_template.SizeHeight;
            corelApp.ActiveDocument.AddPages(pageNum);

            IEnumerator enumerator = corelApp.ActiveDocument.Pages.GetEnumerator();
            corel.Page current_page;
            list_index = 1;
            while (enumerator.MoveNext())
            {
                current_page = (corel.Page)enumerator.Current;
                current_page.Activate();
                current_page.SetSize(dx * 4, dy * 4);
               

                System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                stopwatch.Start(); // 开始监视代码运行时间
                myOptimize(true, true);
                MakeAPage(dx, dy);
                myOptimize(true, false);
                stopwatch.Stop(); // 停止监视
                rTB_info.AppendText("每页运行时间："+stopwatch.Elapsed.TotalMilliseconds.ToString() + "\n");
            }
            list_index = 1;
        }

        //btn test2
        private void button4_Click(object sender, EventArgs e)
        {
        }

        //show file dialog & get the table's path
        private void button2_Click(object sender, EventArgs e)
        {
            String dataPath = "";
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = "C:\\Users\\10347\\Desktop\\cdr";    //打开对话框后的初始目录
            fileDialog.Filter = "表格文件|*.csv;*.xlsx";
            fileDialog.RestoreDirectory = false;    //若为false，则打开对话框后为上次的目录。若为true，则为初始目录
            if (fileDialog.ShowDialog() == DialogResult.OK)
                dataPath = System.IO.Path.GetFullPath(fileDialog.FileName);

            tB_tablePath.Text = dataPath;
            if (dataPath != "")
            {
                FileStream fs = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.None);
                
                if(fs != null)
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
                    sr.Close();
                }
            }
            lb_dcount.Text = datas.Count.ToString();

            int qrcount = 0;
            foreach(string[]data in datas)
            {
                if (!data[2].Contains("号"))
                    data[2] = data[2] + "号";
                string[] dirs1 = getFile(imgPath, data[2]+"(左");
                string[] dirs2 = getFile(imgPath, data[2]+"(右");

                //the path is good, add to the dict
                if (dirs1.Length == 1 && dirs2.Length == 1)
                {
                    string[] key = new string[2];
                    key[0] = dirs1[0]; key[1] = dirs2[0];
                    dict_qrPath[data[2]] = key;
                }
                else
                    rTB_info.AppendText("读取照片路径发生错误：" + data[2]);
                qrcount++;
            }
            lb_qrcount.Text = qrcount.ToString();
        }

        //add template
        private void button5_Click(object sender, EventArgs e)
        {
            corel.Shapes shapes = corelApp.ActiveSelection.Shapes;//get selected shapes
            corel.ShapeRange shapeRange = shapes.All();// used for clone
            
            templates.Add(shapeRange);
            lb_tcount.Text = templates.Count.ToString();
        }

        private void MakeAPage(double dx, double dy)
        {

            int cols = int.Parse(tb_cols.Text);
            int rows = int.Parse(tb_rows.Text);

            
            for (int x = 0; x < 4; x++)
                for (int y = 1; y < 5; y++)
                {

                    if (list_index > datas.Count - 1)
                    {
                        corelApp.Optimization = false;
                        corelApp.ActiveWindow.Refresh();
                        return;
                    }
                    string[] data = (string[])datas[list_index];
                    string key = data[2];
                    if (!data[1].Contains("号"))
                    {
                        corel.ShapeRange shapeRange = (corel.ShapeRange)templates[data[1].Length - 1];
                        MakeNewPlate(shapeRange, data, x * dx, y * dy);
                    }
                    else
                    {
                        corel.ShapeRange shapeRange = (corel.ShapeRange)templates[4];
                        if (data[1].Contains("之"))
                            shapeRange = (corel.ShapeRange)templates[5];
                        else
                            shapeRange = (corel.ShapeRange)templates[data[1].Length - 2];
                        MakeNewPlate(shapeRange, data, x * dx, y * dy);
                    }
                    list_index++;
                }
            
            //corelApp.Optimization = false;
            //corelApp.ActiveWindow.Refresh();
        }

        private void MakeNewPlate(ShapeRange sr_origin, string[] data, double x, double y)
        {
            string key = data[2];

            //clone to the grid
            corel.Shape sh_plate = sr_origin.Shapes.FindShape("plate");
            corel.Shape sh_pn_orign = sr_origin.Shapes.FindShape("H_第1列");
            corel.ShapeRange sr_new = sr_origin.Clone();
            sr_new.SetPosition(x, y);

            //replace things
            corel.Shape sh_pn = sr_new.Shapes.FindShape("H_第1列");
            corel.Text platenum_1 = sr_new.Shapes.FindShape("H_第2列").Text;
            corel.Shape sh_qrLB = sr_new.Shapes.FindShape("qrLB");
            corel.Shape sh_qrRT = sr_new.Shapes.FindShape("qrRT");

            sh_pn.Text.Story.Text = data[0];
            sh_pn.SetSize(sh_pn_orign.SizeWidth, sh_pn_orign.SizeHeight);//resize the font

            if (dict_qrPath.ContainsKey(key))
            {
                myQrcode("a", sh_qrLB, dict_qrPath[key][0]);
                myQrcode("a", sh_qrRT, dict_qrPath[key][1]);
            }

            if (!data[1].Contains("号"))
            {
                platenum_1.Story.Text = data[1];
            }
            else
            {
                string[] num = data[1].Split('号');
                corel.Shape platenum_2 = sr_new.Shapes.FindShape("H_第3列");
                platenum_1.Story.Text = num[0];
                //platenum_1.SetSize(sh_num1_orign.SizeWidth, sh_num1_orign.SizeHeight);//resize the font
                platenum_2.Text.Story.Text = "号" + num[1];
                //platenum_2.SetSize(sh_num2_orign.SizeWidth, sh_num2_orign.SizeHeight);//resize the font
            }
        }
    }
}
