using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE263_Project
{
    internal class User//ชื่อคลาส
    {
        private string id;//สร้างฟิลด์ตัวอักษรและตัวเลข
        private int pw;

    public string ID//อ่านค่าid
        { get { return id; } set { id = value; } }
    public int PW//อ่านค่าpw
        { get { return pw; } set { pw = value; } }      
    public string Welcome(User oc,string name)//สร้างเมธอดWelcomeรับพารามิเตอร์เป็นstring
        {
            string welcome ="" ;//กำหนดตัวแปรwelcomeเป็นตัวอักษร
            welcome = "Welcome!\t"+ oc.ID;//ให้ตัวแปรwelcomeเก็บค่าID
            return welcome;
        }
        public bool isNumeric(User oc, string pass)//สร้างเมธอดชนิดbooleanรับพารามิเตอร์sting
        {
            int password = oc.PW;//สร้างตัวแปรpasswordเก็บค่าPW
            if (int.TryParse(pass, out password))//เช็คค่าให้passเป็นตัวเลข ถ้าใช่เป็นtrue
            {
                return true;
            }
            else return false;

        }
        public bool Lenght (User oc, string lenght) //เมธอดbooleanรับพารามิเตอร์string
        {
            int len;//สร้างตัวแปรชนิดตัวเลข
            len = lenght.Length;//ให้lenมีค่าเท่ากับความยาวของข้อความจากพารามิเตอร์ที่รับ
            if(len == 6)//ถ้าlenมีค่า6 เป็นtrue
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
