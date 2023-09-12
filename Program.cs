using System.Diagnostics.Metrics;

class Program
{
    static void Main()
    {
        List<string> ikoodid = new List<string>();
        List<string> arvud = new List<string>();
        Isikukood isikukood = null;

        while (true)
        {
            Console.Write("~~~\n1 - Lisa isikukood\n2 - Vaata list isikukoodid\n~~~\n");
            int menu = int.Parse(Console.ReadLine());
            if (menu == 1)
            {
                Console.Write("Sisesta isikukood: ");
                string ikood = Console.ReadLine();
                isikukood = new Isikukood(ikood);
                isikukood.Koodikontroll(arvud, ikoodid);
            }
            else if (menu == 2)
            {
                if (isikukood != null)
                {
                    isikukood.NaisedMehed(ikoodid);
                }
                else
                {
                    Console.WriteLine("Palun sisestage isikukood enne nimekirja vaatamist.");
                }
            }
        }
    }
}