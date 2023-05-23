using ConsoleTables;

namespace ThirdTaskItransition
{
    internal class HelpTable
    {
        
        public void Help(int count, string[] argsItems) {

             
            Rules rules = new(count); 
            var items = argsItems.Prepend("User  |  PC"); 
            var table = new ConsoleTable(items.ToArray());

            for (int i = 0; i < count; i++)
            {
                var row = new string[count + 1];
                row[0] = argsItems[i];

                for (int j = 0; j < count; j++)
                {
                    row[j + 1] = rules.whoWon(j, i);
                }

                table.AddRow(row.ToArray());
            }



            table.Write(Format.Alternative);
        }
    }
}
