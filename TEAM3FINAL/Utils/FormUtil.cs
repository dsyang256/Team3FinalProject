using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEAM3FINAL
{
    /// <summary>
    /// 폼 관련 유틸
    /// </summary> - OJH
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

        /// <summary>
        /// 메뉴 생성 메서드 ((제네릭 활용, 고정메뉴인 경우(동적메뉴x))
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mainfrom"></param>
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
        /// <summary>
        /// 동적 메뉴  생성 메서드
        /// </summary>
        /// <param name="mdiParent"></param>
        /// <param name="formName"></param>
        /// <returns></returns>
        public static Form MdiChildrenShow(this FrmMAIN mdiParent, string formName)
        {

            Type type = Type.GetType("TEAM3FINAL." + formName);

            if (type != null)
            {
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.GetType() == type && frm.IsMdiChild)
                    {
                        frm.Dock = DockStyle.Fill;
                        frm.Left = 0;
                        frm.Top = 0;
                        frm.Activate();
                        frm.BringToFront();
                        return frm;
                    }
                }

                Form f = (Form)Activator.CreateInstance(type);
                f.MdiParent = mdiParent;
                f.Dock = DockStyle.Fill;
                f.Left = 0;
                f.Top = 0;
                f.Show();

                return f;
            }
            return null;
        }

    }
}
