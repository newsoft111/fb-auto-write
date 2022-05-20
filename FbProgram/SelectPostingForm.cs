using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BandProgram
{
    public partial class SelectPostingForm : Form
    {
        private List<int> stringToPostingList(string str)
        {
            if (str == null || str.Equals(""))
            {
                return null;
            }
            string[] strArrays = str.Split(new char[] { ',' });
            List<int> nums = new List<int>();
            string[] strArrays1 = strArrays;
            for (int i = 0; i < (int)strArrays1.Length; i++)
            {
                string str1 = strArrays1[i];
                try
                {
                    nums.Add(int.Parse(str1));
                }
                catch
                {
                }
            }
            return nums;
        }

        public delegate void Del(int idx, List<int> postingNumList, List<int> commentNumList, List<int> chattingList);
        private Point mousePoint;
        private SelectPostingForm.Del del_resultHandler;
        public SelectPostingForm()
        {
            InitializeComponent();
        }
        private int idx;
        private List<int> indexList;
        public void applyData(int idx, string bandName, string bandNum, string postingContnets, string commentContents, string chattingContents, SelectPostingForm.Del del_resultHandler)
        {
            this.idx = idx;
            this.textBox2.Text = bandName;
            this.textBox1.Text = bandNum;
            this.del_resultHandler = del_resultHandler;
            this.textBox3.Text = postingContnets;
            this.textBox4.Text = commentContents;
            this.textBox5.Text = chattingContents;
        }

        public void applyIndexList(List<int> indexList, SelectPostingForm.Del del_resultHandler)
        {
            this.indexList = indexList;
            this.del_resultHandler = del_resultHandler;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.del_resultHandler != null)
            {
                if (this.indexList != null)
                {
                    foreach (int num in this.indexList)
                    {
                        List<int> postingList = this.stringToPostingList(this.textBox3.Text);
                        List<int> nums = this.stringToPostingList(this.textBox4.Text);
                        List<int> postingList1 = this.stringToPostingList(this.textBox5.Text);
                        this.del_resultHandler(num, postingList, nums, postingList1);
                    }
                    base.Close();
                    return;
                }
                List<int> nums1 = this.stringToPostingList(this.textBox3.Text);
                List<int> postingList2 = this.stringToPostingList(this.textBox4.Text);
                List<int> nums2 = this.stringToPostingList(this.textBox5.Text);
                this.del_resultHandler(this.idx, nums1, postingList2, nums2);
                base.Close();
            }
        }

    }
}
