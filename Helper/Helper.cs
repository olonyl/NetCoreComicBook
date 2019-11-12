public class Helper
{
    public static int GetUrlComicIDIncrement(string urlAnterior, int currentId)
    {

        int indexOf = urlAnterior.LastIndexOf("/");
        int qty = urlAnterior.Length - indexOf;
        int valueToSum = 1;
        if (urlAnterior.Length > 0 && urlAnterior.Contains("/"))
        {
            string strNum = urlAnterior.Substring(indexOf + 1, qty - 1);
            int nextId;
            bool isNum = int.TryParse(strNum, out nextId);
            if (isNum)
            {
                if (currentId > nextId)
                    valueToSum = 1;
                else valueToSum = -1;
            }
        }
        return valueToSum;
    }
}