namespace Hybel
{
    public enum HorizontalOrder
    {
        LeftToRight = Order.LeftToRight,
        RightToLeft = Order.RightToLeft,
        CenterOutLeftFirst = Order.CenterOutLeftFirst,
        CenterOutRightFirst = Order.CenterOutRightFirst,
        PingPongLeftFirst = Order.PingPongLeftFirst,
        PingPongRightFirst = Order.PingPongRightFirst,
    }

    public enum VerticalOrder
    {
        BottomToTop = Order.LeftToRight,
        TopToBottom = Order.RightToLeft,
        CenterOutBottomFirst = Order.CenterOutLeftFirst,
        CenterOutTopFirst = Order.CenterOutRightFirst,
        PingPongBottomFirst = Order.PingPongLeftFirst,
        PingPongTopFirst = Order.PingPongRightFirst,
    }

    public enum Order
    {
        LeftToRight = 0,
        RightToLeft = 1,
        CenterOutLeftFirst = 2,
        CenterOutRightFirst = 3,
        PingPongLeftFirst = 4,
        PingPongRightFirst = 5,
    }
}