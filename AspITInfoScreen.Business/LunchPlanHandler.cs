﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspITInfoScreen.DAL;

namespace AspITInfoScreen.Business
{
    public class LunchPlanHandler : DBHandler
    {
        public LunchPlan GetLunchPlan(int id)
        {
            LunchPlan lunchPlan = Model.LunchPlans.Where(m => m.Id == id).FirstOrDefault();
            return lunchPlan;
        }
        public bool AddLunchPlan(LunchPlan lunchPlan)
        {
            try
            {
                DbAccess.AddLunchPlan(lunchPlan);
                Model.LunchPlans.Add(lunchPlan);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
        public bool DeleteMessage(int id)
        {
            try
            {
                DbAccess.DeleteMessage(id);
                Model.LunchPlans.RemoveAt(Model.LunchPlans.IndexOf(Model.LunchPlans.Where(m => m.Id == id).FirstOrDefault()));
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
    }
}
