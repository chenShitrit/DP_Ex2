using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using FacebookWrapper;

namespace DP_Targil1
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            FacebookService.s_UseForamttedToStrings = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FacebookForm facebookForm = new FacebookForm();
            facebookForm.StartApp();
        }
    }
}
