namespace FatturaElettronica.Validators;

public class Constants
{
    // Vedi 'EmailType' in https://www.agenziaentrate.gov.it/portale/documents/20143/4631413/Schema_VFPR12.xsd
    public static string EmailRegex = "([!#-'*+/-9=?A-Z^-~-]+(\\.[!#-'*+/-9=?A-Z^-~-]+)*|&quot;(\\[\\]!#-[^-~ \t]|(\\[\t -~]))+&quot;)@([!#-'*+/-9=?A-Z^-~-]+(\\.[!#-'*+/-9=?A-Z^-~-]+)*|\\[[\t -Z^-~]*\\])";

}
