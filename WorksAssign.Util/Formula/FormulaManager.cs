using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.Expressions;


namespace WorksAssign.Util.Formula
{
    public class FormulaManager
    {
        public double TypeWgt { get; set; }
        public double RoleWgt { get; set; }
        public double SeniorityWgt { get; set; }
        public double CCPWgt { get; set; }
        public double SexWgt { get; set; }
        public int CurrentYear { get; set; }
        public int JoinYear { get; set; }
        
        public FormulaManagerValidVariable ValidVariable { get; set; }
        public FormulaManager(double typeWgt, double roleWgt, double seniorityWgt) {
            TypeWgt = typeWgt;
            RoleWgt = roleWgt;
            SeniorityWgt = seniorityWgt;
        }

        public FormulaManager(double typeWgt, double roleWgt, int currentYear, int joinYear) {
            TypeWgt = typeWgt;
            RoleWgt = roleWgt;
            JoinYear = joinYear;
            CurrentYear = currentYear;
        }

        public FormulaManager(int currentYear, int joinYear) {
            JoinYear = joinYear;
            CurrentYear = currentYear;
        }


        public static double DefaultDailyPoint(double typeWgt, double roleWgt, double seniorityWgt) {
            return typeWgt * roleWgt * seniorityWgt;
        }
        
        public static double DefaultSeniority(int currentYear, int joinYear, double weight, double constValue) {
            int serviceYears = currentYear - joinYear;
            if (serviceYears <= 20) {
                return 1;
            }
            else {
                return 1.01 + 0.01 * (serviceYears-20);
            }

            
        }

        public double DailyPoint(string exp) {
            double result = 0;
            if (String.IsNullOrEmpty(exp)) {
                result = DefaultDailyPoint(TypeWgt, RoleWgt, SeniorityWgt);
            }
            else {
                result = ExternalFormulaHandler("DailyPoint",exp);
            }
            return result;

        }

        public double Seniority(string exp) {
            double result = 0;
            if (String.IsNullOrEmpty(exp)) {
                result = DefaultSeniority(CurrentYear,JoinYear,1,0);
            }
            else {
                result = ExternalFormulaHandler("Seniority", exp);
            }
            return result;
        }

        protected double ExternalFormulaHandler(string name, string formula) {
            double result = 0;
            /* we provide args list as below:
             * typeWgt, roleWgt, seniorityWgt, CCPWgt
             * 
             */
            switch (name) {
                case "DailyPoint":
                    formula = formula
                        .Replace("@TypeWgt", TypeWgt.ToString())
                        .Replace("@RoleWgt", RoleWgt.ToString())
                        .Replace("@CCPWgt", CCPWgt.ToString())
                        .Replace("@SeniorityWgt", SeniorityWgt.ToString());
                    break;
                case "Seniority":
                    formula = formula
                        .Replace("@CurrentYear", CurrentYear.ToString())
                        .Replace("@JoinYear", JoinYear.ToString());
                    break;
                case "CCPWgt":
                    formula = formula
                       .Replace("@CCPWgt", CCPWgt.ToString());
                    break;
                default:
                    throw new ArgumentException();
            }

           result =  Eval.Execute<double>(formula);

            return result;
        }

        public FormulaManagerValidVariable CreateValidVariableFlag(string exp) {
            FormulaManagerValidVariable result = FormulaManagerValidVariable.None;
            
            if (exp.Contains("@TypeWgt")) {
                result |= FormulaManagerValidVariable.TypeWgt;
            }
            if (exp.Contains("@RoleWgt")) {
                result |= FormulaManagerValidVariable.RoleWgt;
            }
            if (exp.Contains("@CCPWgt")) {
                result |= FormulaManagerValidVariable.CCPWgt;
            }
            if (exp.Contains("@SeiorityWgt")) {
                result |= FormulaManagerValidVariable.SeniorityWgt;
            }
            if (exp.Contains("@CurrentYear")) {
                result |= FormulaManagerValidVariable.CurrentYear;
            }
            if (exp.Contains("@JoinYear")) {
                result |= FormulaManagerValidVariable.JoinYear;
            }
            if (exp.Contains("@SexWgt")) {
                result |= FormulaManagerValidVariable.SexWgt;
            }
            return result;
        }

       

        public enum FormulaManagerValidVariable
        {   None = 0x0,
            TypeWgt = 0x1,
            RoleWgt = 0x2,
            SeniorityWgt = 0x4,
            CCPWgt = 0x8,
            SexWgt = 0x10,
            CurrentYear = 0x20,
            JoinYear = 0x40
        }
    }

    
}
