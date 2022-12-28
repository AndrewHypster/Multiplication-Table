using System;

namespace Test_tabl_mnoj {

    class Program {

        static void Main() {   //Меню
        Console.WriteLine ("Як вас звати?");
        string name = Console.ReadLine();
        while (name == "Admin"){             // вхід вчителя
            vxidAdmina();
        }

        string nAme = name + " = ";
        Console.WriteLine ("M E N U \n1.Test \n2.Вчити \n");
        short menu = Convert.ToByte (Console.ReadLine());     //Вибір учня

        short user_vidpov1;
        short vidpov;
        byte o = 0;     //оцінка

        while (menu == 1){     // основний тест

            byte ocinka = o;
            Random rnd = new Random ();
            short mnognuk = Convert.ToInt16 (rnd.Next(1, 10));
            short mnogene = Convert.ToInt16 (rnd.Next(1, 10));
            Console.WriteLine("Основний тест\n{0} * {1} = ?", mnognuk, mnogene);
            user_vidpov1 = Convert.ToInt16 (Console.ReadLine ());
            vidpov = Convert.ToInt16 (mnognuk * mnogene);

            while (user_vidpov1 == vidpov) {   
                o ++;  //оцінка
                break;
            }
            if (user_vidpov1 != vidpov){
                Console.WriteLine("Ops, ви помилилися i набрали {0} балiв.", ocinka);
                Console.ReadKey ();
                using (FileStream zapus_ocinok = new FileStream ("Ocinku.txt", FileMode.OpenOrCreate)){
                    string Ocinka = Convert.ToString (o);                    
                    byte [] Name = System.Text.Encoding.Default.GetBytes(nAme);
                    zapus_ocinok.Write(Name, 0, Name.Length);
                    byte [] oCinka = System.Text.Encoding.Default.GetBytes(Ocinka);
                    zapus_ocinok.Write(oCinka, 0, oCinka.Length);
                }
                break;
            }
            else if (ocinka == 12) {
                Console.WriteLine ("Вiтаємо!!! В вас 12 балiв.");
                Console.ReadKey ();
                
                using (FileStream zapus_ocinok = new FileStream ("Ocinku.txt", FileMode.OpenOrCreate)){
                    string Ocinka = Convert.ToString (ocinka);                    
                    byte [] Name = System.Text.Encoding.Default.GetBytes(nAme);
                    zapus_ocinok.Write(Name, 0, Name.Length);
                    byte [] oCinka = System.Text.Encoding.Default.GetBytes(Ocinka);
                    zapus_ocinok.Write(oCinka, 0, oCinka.Length);
                }
                break;
            }

        }

        while (menu == 2) {      // вивчення таблички
            Random rnd = new Random ();
            short mnognuk = Convert.ToInt16 (rnd.Next(1, 10));
            short mnogene = Convert.ToInt16 (rnd.Next(1, 10));
            Console.WriteLine("Вивченя таблички\n{0} * {1} = ? \nЩоб повернутися в меню, напишіть ,,-1''", mnognuk, mnogene);
            short user_vidpov2 = Convert.ToInt16 (Console.ReadLine ());
            vidpov = Convert.ToInt16 (mnognuk * mnogene);
            
            if (vidpov == user_vidpov2){      // учень відповів правильно
                Console.WriteLine("Yes, {0} * {1} = {2}", mnognuk, mnogene, vidpov);
                continue;
            }
            else if (vidpov != user_vidpov2 && user_vidpov2 > 0){    // учень помилився
                Console.WriteLine("No, {0} * {1} = {2}", mnognuk, mnogene, vidpov);
                continue;
            }
            else if (user_vidpov2 == -1)     // учень хоче в меню
                Main();
            else {     // учень набрав казна що
                Console.WriteLine("Error!!!");
                Console.ReadKey ();
                Main();
            }
        }

        static void vxidAdmina() {
            short Password = 1503, password;
            short nomer_vhodu = -1;
            while (Password == 1503 && nomer_vhodu <= 3){
                Console.WriteLine ("Password: ");
                password = Convert.ToInt16 (Console.ReadLine());
                nomer_vhodu ++;
                
                if (Password != password)
                    continue;
                
                else if (Password == password)
                Admin();
                break;
            }
        }

        static void Admin() {
            Console.WriteLine("Ви успiшно ввiйшли!");
            Console.ReadKey();
        }
    }
  }
}