using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserInfo.Entity
{
    class User
    {
        private string name;

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string pwd;
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }
    }
}
