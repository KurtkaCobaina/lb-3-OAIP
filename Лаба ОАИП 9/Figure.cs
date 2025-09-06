using Лаба_ОАИП_9;

public abstract class Figure
{

    public int x;
    public int y;
    public int w;
    public int h;
    public string Name { get; set; }


    abstract public void Draw();
    abstract public void MoveTo(int x, int y);

    public void DeleteF(Figure figure, bool flag = true)
    {
        if (flag == true)
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            ShapeContainer.figureList.Remove(figure);
            this.Clear();
            Init.pictureBox.Image = Init.bitmap;
            foreach (Figure f in ShapeContainer.figureList)
            {
                f.Draw();
            }
        }
        else
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            ShapeContainer.figureList.Remove(figure);
            this.Clear();
            Init.pictureBox.Image = Init.bitmap;
            foreach (Figure f in ShapeContainer.figureList)
            {
                f.Draw();
            }
            ShapeContainer.figureList.Add(figure);
        }
    }

    public void Clear()
    {
        Graphics g = Graphics.FromImage(Init.bitmap);
        g.Clear(Color.White);
    }
}
