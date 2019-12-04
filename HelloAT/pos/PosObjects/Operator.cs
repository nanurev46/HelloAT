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
        bool boss { get; set; }     //Начальник
        bool active { get; set; } //Авторизован в данный момент

        public Operator (string code, string name)//если указываем только имя - не начальник
        {
            this.code = code;
            this.name = name;

            if(this.name.Contains("Стрелкова") || this.name.Contains("Брусова"))
            {
                this.boss = true;
            }
            else
            {
                this.boss = false;
            }

            this.active = false;
                
        }

        public Operator(string code, string name, bool boss)
        {
            this.code = code;
            this.name = name;
            this.boss = boss;
            this.active = false;
        }
        //
        // Summary:
        //Возвращает true, если оператор - начальнмк или зам 
        public bool isBoss()
        {
            if (this.boss) { return true; } else { return false; }  
        }
        //
        // Summary:
        //Возвращает true, если оператор авторизован 
        public bool isActive()
        {
            if (this.active) { return true; } else { return false; }
        }

    }
}
