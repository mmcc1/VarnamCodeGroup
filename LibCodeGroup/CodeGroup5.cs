using System.Text;


namespace LibCodeGroup
{
    /// <summary>
    /// CodeGroup5 converts a byte array (usually ciphertext) to a string of text (5 char per byte) as defined in the lookup.
    /// 
    /// Note
    /// Feel free to change the lettering in the lookup table.  This will make your encoding more unique and hard to match
    /// to bytes.
    /// </summary>
    public static class CodeGroup5
    {
        private static string[] lookup = new string[]
        {
            "AAAAA", "ABAAA", "ACAAA", "ADAAA", "AEAAA", "AFAAA", "AGAAA", "AHAAA", "AIAAA", "AJAAA", "AKAAA", "ALAAA", "AMAAA", "ANAAA", "AOAAA", "APAAA", "AQAAA", "ARAAA", "ASAAA", "ATAAA", "AUAAA", "AVAAA", "AWAAA", "AXAAA", "AYAAA", "AZAAA",
            "BAAAA", "BBAAA", "BCAAA", "BDAAA", "BEAAA", "BFAAA", "BGAAA", "BHAAA", "BIAAA", "BJAAA", "BKAAA", "BLAAA", "BMAAA", "BNAAA", "BOAAA", "BPAAA", "BQAAA", "BRAAA", "BSAAA", "BTAAA", "BUAAA", "BVAAA", "BWAAA", "BXAAA", "BYAAA", "BZAAA",
            "CAAAA", "CBAAA", "CCAAA", "CDAAA", "CEAAA", "CFAAA", "CGAAA", "CHAAA", "CIAAA", "CJAAA", "CKAAA", "CLAAA", "CMAAA", "CNAAA", "COAAA", "CPAAA", "CQAAA", "CRAAA", "CSAAA", "CTAAA", "CUAAA", "CVAAA", "CWAAA", "CXAAA", "CYAAA", "CZAAA",
            "DAAAA", "DBAAA", "DCAAA", "DDAAA", "DEAAA", "DFAAA", "DGAAA", "DHAAA", "DIAAA", "DJAAA", "DKAAA", "DLAAA", "DMAAA", "DNAAA", "DOAAA", "DPAAA", "DQAAA", "DRAAA", "DSAAA", "DTAAA", "DUAAA", "DVAAA", "DWAAA", "DXAAA", "DYAAA", "DZAAA",
            "EAAAA", "EBAAA", "ECAAA", "EDAAA", "EEAAA", "EFAAA", "EGAAA", "EHAAA", "EIAAA", "EJAAA", "EKAAA", "ELAAA", "EMAAA", "ENAAA", "EOAAA", "EPAAA", "EQAAA", "ERAAA", "ESAAA", "ETAAA", "EUAAA", "EVAAA", "EWAAA", "EXAAA", "EYAAA", "EZAAA",
            "FAAAA", "FBAAA", "FCAAA", "FDAAA", "FEAAA", "FFAAA", "FGAAA", "FHAAA", "FIAAA", "FJAAA", "FKAAA", "FLAAA", "FMAAA", "FNAAA", "FOAAA", "FPAAA", "FQAAA", "FRAAA", "FSAAA", "FTAAA", "FUAAA", "FVAAA", "FWAAA", "FXAAA", "FYAAA", "FZAAA",
            "GAAAA", "GBAAA", "GCAAA", "GDAAA", "GEAAA", "GFAAA", "GGAAA", "GHAAA", "GIAAA", "GJAAA", "GKAAA", "GLAAA", "GMAAA", "GNAAA", "GOAAA", "GPAAA", "GQAAA", "GRAAA", "GSAAA", "GTAAA", "GUAAA", "GVAAA", "GWAAA", "GXAAA", "GYAAA", "GZAAA",
            "HAAAA", "HBAAA", "HCAAA", "HDAAA", "HEAAA", "HFAAA", "HGAAA", "HHAAA", "HIAAA", "HJAAA", "HKAAA", "HLAAA", "HMAAA", "HNAAA", "HOAAA", "HPAAA", "HQAAA", "HRAAA", "HSAAA", "HTAAA", "HUAAA", "HVAAA", "HWAAA", "HXAAA", "HYAAA", "HZAAA",
            "IAAAA", "IBAAA", "ICAAA", "IDAAA", "IEAAA", "IFAAA", "IGAAA", "IHAAA", "IIAAA", "IJAAA", "IKAAA", "ILAAA", "IMAAA", "INAAA", "IOAAA", "IPAAA", "IQAAA", "IRAAA", "ISAAA", "ITAAA", "IUAAA", "IVAAA", "IWAAA", "IXAAA", "IYAAA", "IZAAA",
            "JAAAA", "JBAAA", "JCAAA", "JDAAA", "JEAAA", "JFAAA", "JGAAA", "JHAAA", "JIAAA", "JJAAA", "JKAAA", "JLAAA", "JMAAA", "JNAAA", "JOAAA", "JPAAA", "JQAAA", "JRAAA", "JSAAA", "JTAAA", "JUAAA", "JVAAA"
        };

        public static string[] GenerateLookup()
        {
            lookup = Generate.CodeGroup5Lookup();
            return lookup;
        }

        public static string ConvertToCode(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                sb.Append(lookup[(int)data[i]]);

            return sb.ToString();
        }

        public static byte[] ConvertFromCode(string data)
        {
            byte[] decoded = new byte[data.Length / 5];
            int index = 0;

            for (int i = 0; i < decoded.Length; i++)
                decoded[i] = (byte)FindIndex(data[index++].ToString() + data[index++].ToString() + data[index++].ToString() + data[index++].ToString() + data[index++].ToString());

            return decoded;
        }

        private static int FindIndex(string data)
        {
            for (int i = 0; i < lookup.Length; i++)
                if (lookup[i] == data)
                    return i;

            return -1;
        }
    }
}
