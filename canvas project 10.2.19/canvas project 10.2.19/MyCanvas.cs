using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canvas_project_10._2._19
{
    public class MyCanvas
    {
        public const int MAX_WIDTH= 800;
        public const int MAX_HIGHT = 600;
        private static int buttonIndex = 0;
        private static int MaxButtons = 3;
        private static MyButton[] buttons = new MyButton[MaxButtons];


        public static bool CreateNewButton(int x1,int x2,int y1,int y2)
        {
            if(buttonIndex<MaxButtons)
            {
                MyButton button = new MyButton(new Point(x1, y1), new Point(x2, y2));
                buttons[buttonIndex] = button;
                buttonIndex++;
                return true;
            }
            return false;
                 
        }

        public static void MoveButton(int buttonNumber,int x, int y)
        {
            int a = buttons[buttonNumber].GetTopLeft().GetX() + x;
            int b = buttons[buttonNumber].GetTopLeft().GetY() + y;
            int c= buttons[buttonNumber].GetBottomRight().GetX() + x;
            int d= buttons[buttonNumber].GetBottomRight().GetY() + y;
            buttons[buttonNumber] = new MyButton(new Point(a, b), new Point(c, d));

        }

        public static bool DeleteLastButton()
        {
            if (buttonIndex > 0)
            {
               
                buttonIndex = buttonIndex - 1;
                return true;
            }
            else
                return false;
        }
        public static void ClearAllButtons()
        {
            while(buttonIndex>0)
            {
                
                buttonIndex = buttonIndex - 1;
            }

        }
        public static int GetCurrentNumberOfButtons()
        {
            return MyCanvas.buttonIndex;
        }
        public static int GetMaxNumberOfButtons()
        {
            return MyCanvas.MaxButtons;
        }
        public static int GetTheMaxWidthOfAButton()
        {
            int maxWidth=0;

            for (int index = 0; index < buttonIndex; index++)
            {
                int b = buttons[index].GetWidth();
                if (b>maxWidth)
                {
                    maxWidth = b;
                }
            }
            return maxWidth;
        }
        public static int GetTheMaxHightOfAButton()
        {
            int maxHigh = 0;

            for (int index = 0; index < buttonIndex; index++)
            {
                int b = buttons[index].GetWidth();
                if (b > maxHigh)
                {
                    maxHigh = b;
                }
            }
            return maxHigh;
        }
        public static bool IsPointInsideAButton(int x,int y)
        {
            
            for (int i = 0; i < buttons.Length; i++)
            {
                if (x < buttons[i].GetTopLeft().GetX() && x > buttons[i].GetBottomRight().GetX() && y <buttons[i].GetBottomRight().GetY()&&y>buttons[i].GetTopLeft().GetY())
                {
                    return true;
                }

            }

            return false; 
        }
        public static bool CheckIfAnyButtonIsOverLapping()
        {
            for (int i = 0; i <buttons.Length; i++)
            {
               if(MyCanvas.IsPointInsideAButton(buttons[i].GetTopLeft().GetX(),buttons[i].GetTopLeft().GetY())==true|| MyCanvas.IsPointInsideAButton(buttons[i].GetBottomRight().GetX(), buttons[i].GetBottomRight().GetY())==true)
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < buttons.Length; i++)
            {
                result = result + $"{buttons[i].GetBottomRight()}+{buttons[i].GetTopLeft()}\n";
            }
            return $"there are {buttonIndex} buttuns,the buttuns are:"+result ;
        }
        public static void Print()
        {
            string result = "";
            for (int i = 0; i < buttons.Length; i++)
            {
                result = result + $"{buttons[i].GetBottomRight()}+{buttons[i].GetTopLeft()}\n";
            }
            Console.WriteLine( $"there are {buttonIndex} buttuns,the buttuns are:" + result);
        }
    }

}
