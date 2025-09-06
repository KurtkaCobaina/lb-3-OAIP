using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_ОАИП_9
{
    
        public class Rectagle : Figure
        {



            public override void Draw()
            {
            if (!((this.x < 0 && this.y < 0) || (this.y < 0) || (this.x > Init.pictureBox.Width && this.y < 0) || (this.x + this.w > Init.pictureBox.Width) || (this.x > Init.pictureBox.Width && this.y > Init.pictureBox.Height) || (this.y + h > Init.pictureBox.Height) || (this.x < 0 && this.y > Init.pictureBox.Height) || (this.x < 0)))
            {
                Graphics g = Graphics.FromImage(Init.bitmap);
                g.DrawRectangle(Init.pen, this.x, this.y, this.w,
                this.h);
                Init.pictureBox.Image = Init.bitmap;
            }
            else
            {
                ShapeContainer.figureList.Remove(this);
                MessageBox.Show("Неверный размер");
                
            }
        }
            public Rectagle(int x, int y, int w, int h, string name) : this()
            {
                this.Name = name;
                this.x = x;
                this.y = y;
                this.w = w;
                this.h = h;

            }

            public Rectagle()
            {
                this.x = 0;
                this.y = 0;
                this.w = 0;
                this.h = 0;
            }
            public override void MoveTo(int x, int y)
            {
            if (!((this.x + x < 0 && this.y + y < 0) || (this.y + y < 0) || (this.x + x > Init.pictureBox.Width && this.y + y < 0) || (this.x + x + this.w > Init.pictureBox.Width) || (this.x + x > Init.pictureBox.Width && this.y + y > Init.pictureBox.Height) || (this.y + y + h > Init.pictureBox.Height) || (this.x + x < 0 && this.y + y > Init.pictureBox.Height) || (this.x + x < 0)))
            {

                this.x += x;
                this.y += y;
                this.DeleteF(this, false);
                this.Draw();
            }
            else
            {

                MessageBox.Show("Превышен допустимый размер");
            }
        }


        }
    }

