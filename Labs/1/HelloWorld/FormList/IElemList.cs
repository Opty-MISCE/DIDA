using System.Collections.Generic;
using System.IO;

namespace WindowsFormsApp {
    internal interface IElemList {
        void Insert(string ele);

        string Show();

        void Clear();

        void Save();
    }

    internal class ElemList : IElemList {
        private List<string> elems = new List<string>();

        public void Insert(string ele) {
            elems.Add(ele);
        }

        public string Show() {
            string res = "";
            elems.ForEach(e => res += e + "\r\n");
            return res;
        }

        public void Clear() {
            elems.Clear();
        }

        public void Save() {
            using (TextWriter tw = new StreamWriter(".\\Output.txt", false)) {
                tw.Write(Show());
            }
        }
    }
}
