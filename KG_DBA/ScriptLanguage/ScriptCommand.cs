using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace KG_DBA.ScriptLanguage
{
    /********
     * this class describe the definition of command in script language
     * For example:
     * cd command:
     * Name: cd, defineRegString: cd [/D] [path], Synonyms: chdir
     * 
     * Example2:
     * netsh [-a AliasFile] [-c Context] [-r RemoteMachine] [-u [DomainName\]UserName] [-p Password | *]
             [Command | -f ScriptFile]
     * ************/
    public class ScriptCommand
    {
        public ScriptCommand()
        {
            Parameters = new Dictionary<string, string>();
            Synonyms = new List<string>();
        }

        public ScriptCommand(String defineRegString):this()
        {
         
            this.DefineRegString = defineRegString;
            AnalysisReg();
        }

        public void AnalysisReg()
        {
            Dictionary<string, string> replaceHolder = new Dictionary<string, string>();

            


            string[] words = DefineRegString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Count() == 0)
            {
                return;
            }
            this.Name = words[0];

        }

        
        public string Name { get; set; }
        public String Description { get; set; }
        public string DefineRegString { get; set; }

        public Dictionary<String,String> Parameters { get; set; }
        
        public List<string> Synonyms { get; set; }
    }

    public class ScriptClause
    {
        public string PlaceHolderBoundary = "/*{0}*/";
        public string PlaceHolderNameGenerator()
        {
            return Guid.NewGuid().ToString();
        }

        public ScriptClause()
        {
            ChildrenClause = new List<ScriptClause>();
        }
        Dictionary<String, String> blockpair;
        public ScriptClause(String definingString, Dictionary<String, String> blockpair):this()
        {
            this.blockpair= blockpair;
            String de = definingString;
            while (true)
            {
                int start = de.ToArray<char>().Select(c => c.ToString()).ToList().FindIndex(c => blockpair.Keys.Contains(c));
                if (start < 0)
                {
                    ClauseContent = de;
                    break;
                }
                string startChar = de[start].ToString();
                int endIndex = GetPairEndIndex(de, start);
                string childclauseContent = de.Substring(start+1, endIndex - start -1);
                string childclauseName = string.Format(PlaceHolderBoundary, PlaceHolderNameGenerator());
                de = de.Remove(start, endIndex - start + 1);
                de = de.Insert(start, childclauseName);
                ChildrenClause.Add(new ScriptClause(childclauseName, childclauseContent, blockpair));
            }
            
        }

        public ScriptClause(String name, String definingString, Dictionary<String, String> blockpair) : this(definingString, blockpair)
        {
            this.ClauseName = name;
        }

        public int GetPairEndIndex(string content, int startIndex)
        {
            int startCharCount = 1;
            for (int cindex = startIndex + 1; cindex < content.Length; cindex++)
            {
                if (content[cindex] == content[startIndex])
                {
                    startCharCount++;
                }
                else if(content[cindex].ToString()== blockpair[content[startIndex].ToString()])
                {
                    startCharCount--;
                }
                if (startCharCount == 0)
                {
                    return cindex;
                }
            }
            return -1;
        }
        public string ClauseName { get; set; }
        public string ClauseContent { get; set; }

        public List<ScriptClause> ChildrenClause
        {
            get;set;
        }
    }
}
