
namespace XYECOM.Web.BasePage
{
    public class MyDictionary : System.Collections.Generic.Dictionary<string, string> 
    {
        public new string this[string name] 
        {
            get 
            {
                if (this.ContainsKey(name))
                {
                    return base[name];
                }
                return "";
            }
            set 
            {
                this[name] = value;
            }
        }
    }

}
