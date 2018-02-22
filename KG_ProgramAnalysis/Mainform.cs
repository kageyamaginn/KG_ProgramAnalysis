using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KG_DBA;

namespace KG_ProgramAnalysis
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
            Dictionary<String, String> blockBoundary = new Dictionary<string, string>();
            blockBoundary.Add("(", ")");
            blockBoundary.Add("[", "]");
            KG_DBA.ScriptLanguage.ScriptClause s = new KG_DBA.ScriptLanguage.ScriptClause(@"netsh [-a AliasFile] [-c Context] [-r RemoteMachine] [-u [DomainName\]UserName] [-p Password | *] [Command | -f ScriptFile]",
             blockBoundary);

        }
    }
}
