using Emgu.CV;
using Emgu.CV.Structure;

namespace OpenCVAppTest;

public class ColorRange
{
    public static ScalarArray lower = new ScalarArray(new MCvScalar(0, 80, 80));
    public static ScalarArray upper = new ScalarArray(new MCvScalar(255, 255, 255));
    
    
}