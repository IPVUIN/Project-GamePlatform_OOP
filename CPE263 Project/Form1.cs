using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE263_Project
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        User objUser;//สร้างตัวแปรobjUser จากคลาสUser
        private void btnCreateID_Click(object sender, EventArgs e)//อิเวนท์คลิก
        {
            progressBar1.Style = ProgressBarStyle.Blocks;//รูปแบบprogressBar1เป็นแบบBlocks
            progressBar1.Value = 0;//ค่าในprogressBar1มีค่า0
            for (int i = progressBar1.Minimum; i <= progressBar1.Maximum; i++)//คำสั่งลูป ค่าต่ำสุดในprogressBar1ถึงค่าสูงสุด
            {
                progressBar1.Value = i;//ค่าprogressBar1ท่ากับi
                System.Threading.Thread.Sleep(10);//ให้progressbarทำงานใน0.1วิ
            }
            objUser = new User();//เรียกใช้ตัวแปรobjUserจากคลาสUser
            objUser.ID = txtID.Text;//ตัวแปรIDในobjUserมีค่าเท่ากับช่องข้อความtxtID
            if (objUser.isNumeric(objUser, txtPW.Text))//เรียกฟังก์ชันจากคลาสมาเช็คค่าที่พารามิเตอร์ช่องข้อความtxtPw
            {
                if (objUser.Lenght(objUser, txtPW.Text))//เรียกฟังก์ชันจากคลาสมาเช็คค่าที่พารามิเตอร์ช่องข้อความtxtPw
                {
                    MessageBox.Show(objUser.Welcome(objUser, txtID.Text));//โขว์ข้อความจากฟังก์ขันWelcomeในคลาสobjUser ที่พารามิเตอร์txtID
                    tabControl.SelectedTab = lobby;//tabcontrolเปลี่ยนหน้าเป็นlobby
                    tabControl.TabPages.Add(lobby);//addหน้าlobby
                    lblID.Text = objUser.ID;//label lblID มีค่าเท่ากับ objUser.ID ที่กำหนดไว้ในคลาส
                    btnCreateID.Enabled = false;//ปุ่มCreateID หยุดทำงาน
                }
                else//ถ้าไม่ใช่
                {
                    MessageBox.Show("รหัสผ่านต้องเป็นตัวเลข 6 ตัว");//โขว์ข้อความ
                }
            }
            else//ถ้าไม่ใช่
            {
                MessageBox.Show("รหัสผ่าต้องใส่ตัวเลขเท่านั้น!");//โขว์ข้อความ
                progressBar1.Enabled = false; progressBar1.Value = 0; //progressBar1หยุดทำงานและมีค่าเท่ากับศูนย์
            }
        }

        private void MainForm_Load(object sender, EventArgs e)//อิเวนท์จากฟอร์มหลัก
        {
            tabControl.TabPages.Remove(lobby);//tabControlลบหน้าlobby
            tabControl.TabPages.Remove(Football_game);//ลบหน้าFootball_game
            tabControl.TabPages.Remove(Calculation_game);//ลบหน้าCalculation_game
            tabControl.TabPages.Remove(shooting_game);//ลบหน้าshooting_game
            tabControl.TabPages.Remove(tttgame);//ลบหน้า tttgame
            tabControl.TabPages.Remove(settingpage);//ลบหน้าsettigpage
            //
            foreach (Control c in panel1.Controls)//คำสั่งวนลูปตัวแปรcในpanel1
            {
                if (c is Button)//ถ้าcคือปุ่ม
                {
                    c.Click += new System.EventHandler(btn_click);//ตัวแปรc กำหนดให้เป็นอิเวนท์คลิกเท่ากับปุ่มbtn
                }
            }
        }
        //
        private void btnFBG_Click(object sender, EventArgs e)//อิเวนท์คลิกปุ่ม
        {
            tabControl.SelectedTab = Football_game;//tabControlเปลี่ยนหน้าไปที่ Football_game
            tabControl.TabPages.Add(Football_game);//เพิ่มหน้าFootball_game
            btnFBG.Enabled = false;//ปุ่ม btnFBG ปิดการทำงาน
            btncal.Enabled = false;//ปุ่ม btncal ปิดการทำงาน
            btnshooting.Enabled = false;//ปุ่ม btnshooting ปิดการทำงาน
            btntttgame.Enabled = false;//ปุ่ม btntttgame ปิดการทำงาน
            label7.Text = objUser.ID;//label7เท่ากับIDในobjUser
        }

        int count = 0, score = 0;//สร้างตัวแปรcountกับscoreชนิดตัวเลขมีค่า0

        private void btnkick_Click_1(object sender, EventArgs e)//อิเวนท์คลิกปุ่ม
        {
            Random rd = new Random();
            int gkp = rd.Next(1, 5);
            int kick = 0;//สร้างตัวแปรชนิดตัวเลข ให้ตัวแปรkickเท่ากับ0
            count++;//ให้countบวก1
            if (rad1.Checked)//เช็คค่าที่rad1 ถ้าเป็นจริง
            {
                kick = 1;//kickจะเท่ากับ1
                pgbball.Location = new Point(282, 199);//ให้รูปpgbballเปลี่ยนตำแหน่งตามกำหนด
            }
            else if (rad2.Checked)// หรือถ้า rad2 เป็นจริง
            {
                kick = 2;//kickจะเท่ากับ2
                pgbball.Location = new Point(282, 268);//ให้รูปpgbballเปลี่ยนตำแหน่งตามกำหนด
            }
            else if (rad3.Checked)// หรือถ้า rad3 เป็นจริง
            {
                kick = 3;//kickจะเท่ากับ3
                pgbball.Location = new Point(390, 268);//ให้รูปpgbballเปลี่ยนตำแหน่งตามกำหนด
            }
            else if (rad4.Checked)// หรือถ้า rad4 เป็นจริง
            {
                kick = 4;//kickจะเท่ากับ4
                pgbball.Location = new Point(488, 199);//ให้รูปpgbballเปลี่ยนตำแหน่งตามกำหนด
            }
            else if (rad5.Checked)// หรือถ้า rad5 เป็นจริง
            {
                kick = 5;//kickจะเท่ากับ5
                pgbball.Location = new Point(488, 268);//ให้รูปpgbballเปลี่ยนตำแหน่งตามกำหนด
            }
            else//ถ้าไม่ใช่
            {
                score = 0; gkp = 0;//ตัวแปรscore gkp count เท่ากับ0
                count = 0;
                MessageBox.Show("กรุณาเลือกตำแหน่งที่ต้องการยิง");//โขว์ข้อความ
            }
            if (gkp == 1)//ถ้าgkpมีค่าเท่ากับ1
            {
                pgbfootball.Image = Image.FromFile("gkpe.PNG");//pgbfootballเป็นรูปตามที่กำหนด
            }
            else if (gkp == 2)//หรือถ้ามีค่าเท่ากับ2
            {
                pgbfootball.Image = Image.FromFile("gkpd.PNG");//pgbfootballเป็นรูปตามที่กำหนด
            }
            else if (gkp == 3)//หรือถ้ามีค่าเท่ากับ3
            {
                pgbfootball.Image = Image.FromFile("gkpa1.PNG");//pgbfootballเป็นรูปตามที่กำหนด
            }
            else if (gkp == 4)//หรือถ้ามีค่าเท่ากับ4
            {
                pgbfootball.Image = Image.FromFile("gkpc.PNG");//pgbfootballเป็นรูปตามที่กำหนด
            }
            else if (gkp == 5)//หรือถ้ามีค่าเท่ากับ5
            {
                pgbfootball.Image = Image.FromFile("gkpb.PNG");//pgbfootballเป็นรูปตามที่กำหนด
            }
            if (gkp != kick)//ถ้าตัวแปร gkpไม่เท่ากับตัวแปรkick
            {
                score++;//scoreบวก1
                txtscore.Text = score.ToString();//ช่องข้อความมีค่าเท่ากับตัวแปรscore
                if (score == 1)//ถ้าตัวแปรscoreเท่ากับ1
                {
                    pictureBox1.BackColor = Color.Green;//pictureBox1 เปลี่ยนสีพื้นหลังเป็นสีเขียว
                }
                if (score == 2)//ถ้าตัวแปรscoreเท่ากับ2
                {
                    pictureBox2.BackColor = Color.Green;//pictureBox2 เปลี่ยนสีพื้นหลังเป็นสีเขียว
                }
                if (score == 3)//ถ้าตัวแปรscoreเท่ากับ3
                {
                    pictureBox3.BackColor = Color.Green;//pictureBox3 เปลี่ยนสีพื้นหลังเป็นสีเขียว
                }
                if (score == 4)//ถ้าตัวแปรscoreเท่ากับ4
                {
                    pictureBox4.BackColor = Color.Green;//pictureBox4 เปลี่ยนสีพื้นหลังเป็นสีเขียว
                }

            }
            if (count == 5)//ถ้าcountนับถึง5
            {
                rad1.Enabled = false;//radiobutton หยุดการทำงาน
                rad2.Enabled = false;
                rad3.Enabled = false;
                rad4.Enabled = false;
                rad5.Enabled = false;
                btnkick.Enabled = false;//ปุ่มbtnkick หยุดการทำงาน
                if (score == 5)//ถ้าscore มีค่าเท่ากับ5
                {
                    pictureBox5.BackColor = Color.Green;//เปลี่ยนสีพื้นหลังpictureBox5เป็นสีเขียว
                    txtscore.Text = score.ToString();//ช่องความtxtscoreมีค่าเท่ากับตัวแปรscore
                    pgbgiffb.Image = Image.FromFile("fb.GIF");//picturebox pgbgiffb โขว์ภาพGif
                    pgbgiffb.Visible = true;//เปิดการมองเห็นของpicturebox
                    MessageBox.Show("You Win!");//โขว์ข้อความ
                }
                else
                    MessageBox.Show("Your score :" + score);//นำตัวแปรscoreมาโขว์
            }
            label1.Text = count.ToString();//label1 มีค่าเท่ากับตัวแปรcount

        }
        private void btnexitfbg_Click_1(object sender, EventArgs e)//อิเวนท์คลิกปุ่ม
        {
            tabControl.TabPages.Remove(Football_game);//ลบpage football_game
            tabControl.SelectedTab = lobby;//เปลี่ยนหน้าเป็น lobby
            btnFBG.Enabled = true;//เปิดการใช้งานปุ่ม
            btntttgame.Enabled = true;
            btncal.Enabled = true;
            btnshooting.Enabled = true;
        }

        private void btnreset_Click(object sender, EventArgs e)//อิเวนท์คลิก
        {
            count = 0; score = 0;//ตัวแปรcount score เท่ากับ0
            rad1.Enabled = true;//เปิดการใช้งานradiobutton
            rad2.Enabled = true;
            rad3.Enabled = true;
            rad4.Enabled = true;
            rad5.Enabled = true;
            btnkick.Enabled = true;//เปิดการใช้งานปุ่ม
            txtscore.Text = score.ToString();//ช่องข้อความtxtscoreเท่ากับตัวแปรscore
            label1.Text = count.ToString();//label1เท่ากับตัวแปรcount
            pictureBox1.BackColor = Color.Red;//เปลี่ยนสีพื้นหลังpictureboxเป็นสีแดง
            pictureBox2.BackColor = Color.Red;
            pictureBox3.BackColor = Color.Red;
            pictureBox4.BackColor = Color.Red;
            pictureBox5.BackColor = Color.Red;
            pgbfootball.Image = Image.FromFile("gkpa1.PNG");//เปลี่ยนรูปpicturebox
            pgbball.Location = new Point(384, 370);//เปลี่ยนตำแหน่งของ picturebox pgbball
            pgbgiffb.Visible = false;//ปิดการมองเห็นของpicturebox pgbgiffb
        }
        ///
        private void btncal_Click(object sender, EventArgs e)//อิเวนท์คลิก
        {
            tabControl.SelectedTab = Calculation_game;//เปลี่ยนpageไปที่Calculation_game
            tabControl.TabPages.Add(Calculation_game);//เพิ่มหน้าCalculation_game
            label8.Text = objUser.ID;//ให้label8ที่เป็นข้อความมีค่าเท่ากับIDในobjUser
            btnFBG.Enabled = false;//ให้ปุ่มหยุดทำงาน
            btncal.Enabled = false;
            btnshooting.Enabled = false;
            btntttgame.Enabled = false;
        }
        private int sum, sc = 0, time = 20;//สร้างตัวแปรชนิดตัวเลข และกำหนดtimeไปที่20
        private int mark, n1, n2;//สร้างตัวแปรชนิดตัวเลข


        private void btnstart_Click(object sender, EventArgs e)//อิเวนท์
        {
            timer1.Start();//timer1เริ่มนับเวลา
            timer1.Interval = 1000;//กำหนดการนับเวลาเป็น1วินาที
            Random rd = new Random();//สร้างตัวแปร  เป็นค่าrandom
            Random r2 = new Random();
            n1 = rd.Next(1, 10);//ให้ n1 randomเลข1ถึง10
            n2 = rd.Next(1, 10);//ให้ n2 randomเลข1ถึง10
            mark = r2.Next(0, 3);//ให้ mark randomเลข0ถึง3
            txtn1.Text = n1.ToString();//ให้ช่องข้อความเก็บค่าตัวแปร
            txtn2.Text = n2.ToString();
            if (mark == 0)//ถ้าmarkมีค่า0
            {
                sum = n1 + n2; txtmark.Text = "+";//sumมีค่าเท่ากับn1บวกn2และช่องข้อความtxtmarkเป็นเครื่องหมายบวก
            }
            else if (mark == 1)//หรือถ้าmarkมีค่า1
            {
                sum = n1 - n2; txtmark.Text = "-";//sumมีค่าเท่ากับn1ลบn2และช่องข้อความtxtmarkเป็นเครื่องหมายลบ
            }
            else if (mark == 2)//หรือถ้าmarkมีค่า2
            {
                sum = n1 * n2; txtmark.Text = "x";//sumมีค่าเท่ากับn1คูณn2และช่องข้อความtxtmarkเป็นเครื่องหมายคูณ
            }
            btnreply.Enabled = true;//ปุ่มเริ่มทำงาน
        }
        private void btnreply_Click(object sender, EventArgs e)//อิเวนท์คลิก
        {
            if (objUser.isNumeric(objUser, txtans.Text))//เรียกใช้ฟังก์ชันจากคลาสobjUserมาเช็คค่าที่ช่องข้อความtxtans
            {
                btnreply.Enabled = false;//ปุ่มปิดทำงาน
                int ans = Convert.ToInt32(txtans.Text);//รับค่าจากช่องข้อความมาแปลงเป็นตัวเลขเก็บในตัวแปรans
                if (mark == 0)//ถ้าmarkเท่ากับ0
                {
                    sum = n1 + n2;//sumมีค่าเท่ากับn1บวกn2
                }
                else if (mark == 1)//หรือถ้าmarkเท่ากับ1
                {
                    sum = n1 - n2;//sumมีค่าเท่ากับn1ลบn2
                }
                else if (mark == 2)//หรือถ้าmarkเท่ากับ2
                {
                    sum = n1 * n2;//sumมีค่าเท่ากับn1คูณn2
                }
                if (sum == ans)//ถ้าตัวแปรsumมีค่าเท่ากับans
                {
                    sc = sc + 1;//ให้ตัวแปรscบวก1
                    txtsc.Text = sc.ToString();//ให้ช่องข้อความมีค่าเท่ากับตัวแปรsc
                }
                else
                {
                    MessageBox.Show("ผิด!");//โชว์ข้อความ
                }
            }
            else
            {
                MessageBox.Show("ใส่ตัวเลขเท่านั้น!");//โชว์ข้อความ
            }

        }
        private void timer1_Tick(object sender, EventArgs e)//อิเวนท์timerนับเวลา
        {
            time--;//ให้ตัวแปรtimeลดลง1
            if (time == 0)//ถ้าtimeมีค่า0
            {
                timer1.Stop();//ให้timer1หยุดนับเวลา
                MessageBox.Show("Your score : " + sc.ToString());//โชว์ข้อความตัวแปรsc
                btnstart.Enabled = false;//ปิดการใช้งานปุ่ม
                btnreply.Enabled = false;
            }

            txttime.Text = time.ToString();//ช่องข้อความมีค่าเท่ากับตัวแปรtime
        }

        private void btnretime_Click(object sender, EventArgs e)//อิเวนท์คลิก
        {
            sc = 0; txtsc.Text = sc.ToString();//ให้ค่าscกับเป็นที่0
            time = 20; txttime.Text = time.ToString();//ให้timeกลับไปที่20
            btnstart.Enabled = true;//เปิดการใช้งานปุ่ม
            btnreply.Enabled = false ;//ปิดการใช้งานปุ่ม
            timer1.Stop();            //หยุดนับเวลา
        }


        private void btnexitcal_Click(object sender, EventArgs e)//อิเวนท์คลิก
        {
            tabControl.SelectedTab = lobby;//เปลี่ยนหน้าไปที่lobby
            tabControl.TabPages.Remove(Calculation_game);//ลบหน้าCalculation_game
            btnFBG.Enabled = true;//เปิดการใช้งานปุ่ม
            btntttgame.Enabled = true;
            btncal.Enabled = true;
            btnshooting.Enabled = true;
        }

        ///  
        int kill = 0, timeshoot = 30;//สร้างตัวแปรชนิดตัวเลขเก็บค่าkillและ timeshootไว้ที่30


        private void btnshooting_Click(object sender, EventArgs e)//อิเวนท์คลิก
        {
            tabControl.SelectedTab = shooting_game;//เปลี่ยนไปที่หน้าshooting_game
            tabControl.TabPages.Add(shooting_game);//เพิ่มหน้าshooting_game
            label9.Text = objUser.ID;//ให้label9 ข้อความ มีค่าเท่ากับIDให้objUser
            btnFBG.Enabled = false;//ปิดการใช้งานปุ่ม
            btncal.Enabled = false;
            btnshooting.Enabled = false;
            btntttgame.Enabled = false;
        }

        private void btntarget_Click_1(object sender, EventArgs e)//อิเวนท์คลิก
        {
            kill++;//ตัวแปรkillเพิ่ม1
            txtkill.Text = kill.ToString();//ให้ช่องข้อความมีค่าเท่ากับตัวแปรkill
            Random randombtn = new Random();//สร้างตัวแปรrandombtn เป็นค่าrandom
            btntarget.Location = new Point(randombtn.Next(164, 547), randombtn.Next(145, 344));//สุ่มlocationของปุ่มbtntarget
        }

        private void timer2_Tick(object sender, EventArgs e)//อิเวนท์timerนับเวลา
        {
            timeshoot--;//ตัวแปรtimeshootลดลง1
            lbltimeshoot.Text = timeshoot.ToString();//ให้label ข้อความมีค่าเท่ากับตัวแปรtimeshoot
            if (timeshoot == 0)//ถ้าตัวแปรtimeshootเท่ากับ0
            {
                timer2.Stop();//timer2หยุดนับ
                MessageBox.Show("Your kills :" + kill);
                btntarget.Enabled = false;
                btnst.Enabled = false;

            }

        }
        private void btnst_Click(object sender, EventArgs e)//อิเวนท์คลิก
        {
            timer2.Start();//timer2เริ่มนับเวลา
            timer2.Interval = 1000;//timer2 นับเวลา1วินาที
            btntarget.Enabled = true;
        }
        private void btnRestart_Click(object sender, EventArgs e)//อิเวนท์คลิก
        {
            timeshoot = 30;//ตัวแปรtimeshootมีค่าเท่ากับ30
            kill = 0;//killเท่ากับ0
            lbltimeshoot.Text = timeshoot.ToString();//ให้labelข้อความมีค่าเท่ากับตัวแปรtimeshoot
            btntarget.Enabled = false;
            btnst.Enabled = true;
            
            timer2.Stop();//หยุดนับเวลา
        }

        private void btnexitshooting_Click(object sender, EventArgs e)//อิเวนท์คลิก
        {
            tabControl.SelectedTab = lobby;//เปลี่ยนไปหน้าlobby
            tabControl.TabPages.Remove(shooting_game);//ลบหน้าshooting_game
            btnFBG.Enabled = true;
            btntttgame.Enabled = true;
            btncal.Enabled = true;
            btnshooting.Enabled = true;
        }

        ///

        private void btntttgame_Click(object sender, EventArgs e)//อิเวนท์คลิก
        {
            tabControl.SelectedTab = tttgame;//เลือกหน้าไปที่tttgame
            tabControl.TabPages.Add(tttgame);//เพิ่มหน้าtttgame
            label10.Text = objUser.ID;//ให้labelข้อความมีค่าเท่ากับIDในobjUser
            btnFBG.Enabled = false;
            btncal.Enabled = false;
            btnshooting.Enabled = false;
            btntttgame.Enabled = false;
        }
        private void btnexitsuit_Click(object sender, EventArgs e)//อิเวนท์คลิก
        {
            tabControl.SelectedTab = lobby;//เปลี่ยนไปที่หน้าlobby
            tabControl.TabPages.Remove(tttgame);//ลบหน้าtttgameออก
            btnFBG.Enabled = true;
            btntttgame.Enabled = true;
            btncal.Enabled = true;
            btnshooting.Enabled = true;
        }

        int XO = 0;//สร้างตัวแปร XO ชนิดตัวเลข

        public void btn_click(object sender, EventArgs e)//อิเวนท์คลิก
        {
            Button btn = (Button)sender;//สร้างตัวแปรbtn เป็นButton
            if (btn.Text.Equals(""))//ถ้าปุ่มมีข้อความว่างเปล่า
            {
                if (XO % 2 == 0)//ถ้าXOหาร2แล้วเท่ากับ0
                {
                    btn.Text = "X";//ให้ปุ่มขุ้นข้อความXที่ปุ่ม
                    btn.ForeColor = Color.Blue;//เปลี่ยนสีปุ่ม
                    lblXO.Text = "O turn now";//เปลี่ยนlabelเป็นข้อความตามกำหนด
                    gettheWinner();//เรียกฟังก์ชันมาใช้
                    ifwin();
                }
                else
                {
                    btn.Text = "O";//ให้ปุ่มขุ้นข้อความOที่ปุ่ม
                    btn.ForeColor = Color.Red;//เปลี่ยนสีปุ่ม
                    lblXO.Text = "X turn now";//เปลี่ยนlabelเป็นข้อความตามกำหนด
                    gettheWinner();//เรียกฟังก์ชันมาใช้
                    ifwin();
                }
            }
            if ((btn.Text == "X")||(btn.Text == "O"))//ถ้าปุ่มมีข้อความXหรือOแล้ว
            {
                btn.Enabled = false;//ปิดการทำงานปุ่ม
            }
            XO++;//ให้XOเพิ่ม1
            
        }
        bool win = false;//ประกาศตัวแปรชนิดboolean ให้winเก็บค่าfalseไว้

        public void gettheWinner()//สร้างฟังก์ชัน
        {//ถ้าปุ่มแรกไม่ว่างเปล่าและเข็คค่าปุ่มถ้ามีค่าเท่ากัน จะเรียกใช้ฟังก์ชันwinEffectและค่าwinจะเป็นtrue
            if (!btn1.Text.Equals("") && btn1.Text.Equals(btn2.Text) && btn1.Text.Equals(btn3.Text))
            {
                winEffect(btn1, btn2, btn3);
                win = true;
            }
            if (!btn4.Text.Equals("") && btn4.Text.Equals(btn5.Text) && btn4.Text.Equals(btn6.Text))
            {
                winEffect(btn4, btn5, btn6);
                win = true;
            }
            if (!btn7.Text.Equals("") && btn7.Text.Equals(btn8.Text) && btn7.Text.Equals(btn9.Text))
            {
                winEffect(btn7, btn8, btn9);
                win = true;
            }
            if (!btn1.Text.Equals("") && btn1.Text.Equals(btn4.Text) && btn1.Text.Equals(btn7.Text))
            {
                winEffect(btn1, btn4, btn7);
                win = true;
            }
            if (!btn2.Text.Equals("") && btn2.Text.Equals(btn5.Text) && btn2.Text.Equals(btn8.Text))
            {
                winEffect(btn2, btn5, btn8);
                win = true;
            }
            if (!btn3.Text.Equals("") && btn3.Text.Equals(btn6.Text) && btn3.Text.Equals(btn9.Text))
            {
                winEffect(btn3, btn6, btn9);
                win = true;
            }
            if (!btn1.Text.Equals("") && btn1.Text.Equals(btn5.Text) && btn1.Text.Equals(btn9.Text))
            {
                winEffect(btn1, btn5, btn9);
                win = true;
            }
            if (!btn3.Text.Equals("") && btn3.Text.Equals(btn5.Text) && btn3.Text.Equals(btn7.Text))
            {
                winEffect(btn3, btn5, btn7);
                win = true;
            }
            if (XO == 8 && win == false)//ถ้าXOและwinมีค่าfalse
            {
                lblXO.Text = "No Winner";//โชว์ข้อความที่label
                MessageBox.Show("Draw!");
            }
        }
        public void ifwin()//สร้างฟังก์ชัน
        {
            foreach (Control c in panel1.Controls)//คำสั่งวนลูปตัวแปรcในpanel1
            {
                if (c is Button)//ให้cเป็นปุ่ม
                {
                    if(win == true)//ถ้าwinมีค่าtrue
                    {
                        c.Enabled = false;//ปุ่มปิดการทำงาน
                    }
                }
            }
        }

        public void winEffect(Button b1, Button b2, Button b3)//สร้างฟังก์ชันมีพารามิเตอร์b1,b2,b3
        {
            b1.BackColor = Color.Green;//เปลี่ยนสีปุ่ม
            b2.BackColor = Color.Green;
            b3.BackColor = Color.Green;

            b1.ForeColor = Color.White;
            b2.ForeColor = Color.White;
            b3.ForeColor = Color.White;
            MessageBox.Show(b1.Text + "\tWin!");
            lblXO.Text = b1.Text + " Win";//โชว์ข้อความ
        }

        private void btnclearXO_Click(object sender, EventArgs e)//อิเวนท์คลิก
        {
            XO = 0;//XOเท่ากับ0
            win = false;//winมีค่าfalse
            lblXO.Text = "Play";
            foreach (Control c in panel1.Controls)//วนลูปในตัวแปรc ในpanel1
            {
                if (c is Button)//ถ้าcเป็นปุ่ม
                {
                    c.Text = "";//ปุ่มไม่มีข้อความ
                    c.BackColor = Color.White;//เปลี่ยนสีปุ่ม
                    c.Enabled = true;//เปิดการใช้งานปุ่ม
                }
            }
        }
        //

        private void btnsetting_Click(object sender, EventArgs e)//อิเวนท์คลิก
        {
            tabControl.SelectedTab = settingpage;//เลือกหน้าsettingpage
            tabControl.TabPages.Add(settingpage);//เพิ่มหน้าsettingpage
            label14.Text = objUser.ID;//ให้labelข้อความมีค่าเท่ากับ IDในpbjUser
            btnsetting.Enabled = false;
        }
        private void btnexitsetting_Click(object sender, EventArgs e)//อิเวนท์คลิก
        {
            tabControl.SelectedTab = lobby;//เลือกหน้าlobby
            tabControl.TabPages.Remove(settingpage);//ลบหน้าsettingpage
            btnsetting.Enabled = true;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)//อิเวนท์เปลี่ยนค่าในcombobox
        {
            switch(comboBox1.SelectedItem)//คำสั่งเช็คค่าในcomboBox1 ในแต่ละcase
            {
                case "Red":pgbbacksetting.BackColor = Color.Red; break;//เปลียนสีรูป
                case "Black": pgbbacksetting.BackColor = Color.Black; break;
                case "White": pgbbacksetting.BackColor = Color.White; break;
                case "Blue": pgbbacksetting.BackColor = Color.Blue; break;
                case "Green": pgbbacksetting.BackColor = Color.Green; break;
                case "Yellow": pgbbacksetting.BackColor = Color.Yellow; break;
                case "Purple": pgbbacksetting.BackColor = Color.Purple; break;
            }
            picboxBackG.BackColor = pgbbacksetting.BackColor;//เปลี่ยนสีรูปให้เท่ากับpgbbacksetting
            pgbbackfb.BackColor = pgbbacksetting.BackColor;
            pgbbackcal.BackColor = pgbbacksetting.BackColor;
            pgbbacksh.BackColor = pgbbacksetting.BackColor;
            pgbbackttt.BackColor = pgbbacksetting.BackColor;
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)//อิเวนท์เปลี่ยนค่าในcombobox
        {         
            switch (comboBox2.SelectedItem)//คำสั่งเช็คค่าในcomboBox2 ในแต่ละcase
            {
                case "Red": label14.ForeColor = Color.Red; break;
                case "Black": label14.ForeColor = Color.Black; break;
                case "White": label14.ForeColor = Color.White; break;
                case "Blue": label14.ForeColor = Color.Blue; break;
                case "Green": label14.ForeColor = Color.Green; break;
                case "Yellow": label14.ForeColor = Color.Yellow; break;
                case "Purple": label14.ForeColor = Color.Purple; break;
            }
            lblID.ForeColor = label14.ForeColor;//เปลี่ยนสีข้อความให้เท่ากับlabel14
            label7.ForeColor = label14.ForeColor;
            label8.ForeColor = label14.ForeColor;
            label9.ForeColor = label14.ForeColor;
            label10.ForeColor = label14.ForeColor;
        }

    }
}

