using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloAT.pos
{//Операторы отделения (для авторизации)
    class Operator
    {
        string code { get; set; }
        string name { get; set; }   //Имя   
        bool boss { get; set; }     //Начальник?

        public Operator (string code, string name)//если указываем только имя - не начальник
        {
            this.code = code;
            this.name = name;
            this.boss = false;
        }

        public Operator(string code, string name, bool boss)
        {
            this.code = code;
            this.name = name;
            this.boss = boss;
        }

    }
}
