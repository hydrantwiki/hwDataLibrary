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
        /// <param name="_hydrants"></param>
        /// <returns></returns>
        public static string GetHydrantCSV(List<Hydrant> _hydrants)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("lat,lon,title,id,marker-color\n");
            
            int i = 1;
            foreach (Hydrant hydrant in _hydrants)
            {
                if (hydrant.Position != null)
                {
                    sb.AppendFormat("{0},{1},{2},{3},#180392\n", 
                        hydrant.Position.Y, hydrant.Position.X, i, hydrant.Guid);
                    i++;
                }
            }
            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }

            return sb.ToString();
        }
    }
}
