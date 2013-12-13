using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for test
/// </summary>
public class test
{
    public test()
    {

    }
}
public interface interfacea
{
    void a();
}
public interface interfaceb
{
    void a();
}
public class A : interfacea, interfaceb
{
    public void a()
    {

    }
}
public class Myclass
{
    Myclass()
    { }
    public string Name;
    public string age;


}

