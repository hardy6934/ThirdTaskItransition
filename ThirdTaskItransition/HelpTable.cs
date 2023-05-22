using ConsoleTables;

namespace ThirdTaskItransition
{
    internal class HelpTable
    {
        
        public void Help(int count, string[] argsItems) {

            Rules rules = new(count);
            var table = new ConsoleTable("Person", "Comp", "Result");

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    table.AddRow(argsItems[i], argsItems[j], rules.whoWon(j,i));
                }

                table.AddRow("NextVale", "NextVale", "NextVale");
            }

            table.Write(Format.Alternative);

        }
    }
}
