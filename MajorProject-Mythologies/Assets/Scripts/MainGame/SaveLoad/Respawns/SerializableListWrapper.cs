using System.Collections.Generic;

public class SerializableListWrapper<T>
{
    public List<T> list;

    public SerializableListWrapper(List<T> list)
    {
        this.list = list;
    }
}
