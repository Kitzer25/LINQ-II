namespace LAB08_MauricioCalderón.Records;

public record PageResult<T>(
    IEnumerable<T> Data,
    int TotalCount,
    int Page,
    int PageSize
 );