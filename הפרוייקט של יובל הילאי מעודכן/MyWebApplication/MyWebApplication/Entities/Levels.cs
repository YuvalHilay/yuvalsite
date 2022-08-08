using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApplication.Entities
{
    public class Levels
    
    {
        private int IdLevel;
        private string LevelName;
        private int MinSumOfBuying;
       private int SumOfProductsToLevelUp;
       private decimal DiscountType;

       public Levels()
        {
        }

        public int idLevel
        {
            get { return IdLevel; }
            set { IdLevel = value; }
        }
        public string levelName
        {
            get { return LevelName; }
            set { LevelName = value; }
        }
        public int minSumOfBuying
        {
            get { return MinSumOfBuying; }
            set { MinSumOfBuying = value; }
        }
        public int sumOfProductsToLevelUp
        {
            get { return SumOfProductsToLevelUp; }
            set { SumOfProductsToLevelUp = value; }
        }
        public decimal discountType
        {
            get { return DiscountType; }
            set { DiscountType = value; }
        }

    }
}