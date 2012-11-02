using System;
using System.Collections.Generic;
using System.Text;

namespace BarTenderController
{    
    public class QueryString
    {
        public const char SEPARATOR = '=';
        public const char PARAM_SEPARATOR = ',';

        private Device device;
        private string action;
        private List<string> subqueries = new List<string>();

        public QueryString(Device device, string action)
        {
            this.device = device;
            this.action = action;
        }

        public Device Device
        {
            get { return this.device; }
            set { this.device = value; }
        }

        public string Action
        {
            get { return this.action; }
            set { this.action = value; }
        }

        public List<string> SubQueries
        {
            get { return this.subqueries; }
            set { this.subqueries = value; }
        }

        public override string ToString()
        {
            string query = ((int)(Device)this.device).ToString() + this.action + SEPARATOR;
            foreach (string sq in subqueries)
            {
                query += sq + PARAM_SEPARATOR;
            }
            return query;
        }
    }
    
    public enum Device
    {
        PUMP = 0, 
        BREATH = 1,
        FORCESENSOR = 2,
        CARDREADER = 3,
        TEST_DEVICE = 9
    }
}
