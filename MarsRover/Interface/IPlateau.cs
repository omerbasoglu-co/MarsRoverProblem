namespace MarsRover.Interface
{
    public interface IPlateau
    {
        Point GetPoint();
        bool IsValid(Point point);
        void SetPoint(Point point);
    }
}
