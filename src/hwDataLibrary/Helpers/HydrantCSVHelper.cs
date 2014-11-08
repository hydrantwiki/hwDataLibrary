using System.Collections.Generic;
using System.Text;
using HydrantWiki.Library.Objects;

namespace HydrantWiki.Library.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class HydrantCSVHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_positions"></param>
        /// <returns></returns>
        public static string GetHydrantCSV(List<HydrantPosition> _positions)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("lat,lon,title,id,marker-color\n");
            
            int i = 1;
            foreach (HydrantPosition hp in _positions)
            {
                sb.AppendFormat("{0},{1},{2},{3},#180392\n", hp.Position.Y, hp.Position.X, i, hp.HydrantGuid);
                i++;
            }
            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }

            return sb.ToString();
        }
    }
}
