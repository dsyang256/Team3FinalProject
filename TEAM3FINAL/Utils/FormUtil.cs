using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEAM3FINAL
{
    /// <summary>
    /// 폼 관련 공통 유틸
    /// </summary>
   public static class FormUtil
    {
        private static Form activeForm = null;
        public static void OpenForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            //pnlContainer.Controls.Add(childForm);
            //pnlContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        //자식폼의 생성 (제네릭 활용, 고정메뉴인 경우(동적메뉴x))
        public static void OpenOrCreateForm<T>(Form mainfrom) where T : Form, new() //T의 제약조건 : Form을 상속, 기본생성자를 가져야함
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(T))
                {
                    //   form.Dock = DockStyle.Fill;
                    //   form.WindowState = FormWindowState.Maximized; //최대화
                    //form.MinimizeBox = false;
                    //form.MaximizeBox = false;
                    form.Activate();
                    form.BringToFront();
                    // form.FormBorderStyle = FormBorderStyle.FixedDialog;

                    //   form.WindowState = FormWindowState.Maximized;
                    //  form.FormBorderStyle = FormBorderStyle.None;
                    form.Dock = DockStyle.Fill;
                    form.Left = 0;
                    form.Top = 0;
                    return;
                }
            }

            T frm = new T();
            frm.MdiParent = mainfrom;
            frm.Dock = DockStyle.Fill;
            frm.Left = 0;
            frm.Top = 0;
            frm.Show();
        }

    }

}
