using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rFile1
{
    class AccountRecordRA : AccountRecord
    {
        public AccountRecordRA() :base()
        {
            //no arg base constructor called

        }
        public AccountRecordRA(int acct, string fn, string ln, double bal) : base(acct,fn,ln,bal)
        {
            //4 arg base constructor called

        }
        public void Write(FileStream raFile)
        {
            BinaryWriter bw = new BinaryWriter(raFile);
            bw.Write(Account);
            formatName(bw, FirstName);
            formatName(bw, LastName);
            bw.Write(Balance);
        }
        private void formatName(BinaryWriter bw, string str)
        {
            StringBuilder sb = new StringBuilder(str);
            sb.Length = 15;
            bw.Write(sb.ToString());
        }
        public void Read(FileStream raFile)
        {
            BinaryReader br = new BinaryReader(raFile);
            Account = br.ReadInt32();
            FirstName = br.ReadString().Replace("\0", " ");
            LastName = br.ReadString().Replace("\0", " ");
            Balance = br.ReadDouble();
        }
    }
}
