namespace CourseCatalogApi.Requests;

public class LessonViewedRequest
{
    public int LessonId { get; set; }
    public float PctViewed { get; set; }
}