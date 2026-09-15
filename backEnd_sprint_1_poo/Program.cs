using backEnd_sprint_1_poo.Modelos;
using backEnd_sprint_1_poo.Menus;

namespace backEnd_sprint_1_poo
{
    internal class Program
    {
        static void Main()
        {
            //var cliente1 = new ContaCorrente("José", 1);

            //cliente1.Depositar(100.00);
            //cliente1.Saque(50.00);


            var menu = new Menu();
            menu.CriarUsuario();


        }
    }
}
