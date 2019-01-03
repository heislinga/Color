public struct LanConnnectionInfo
{
    public string ipAddress;
    public int port;
    public string name;

    public LanConnnectionInfo(string fromAddress, string data)
    {
        string[] tokens = data.Split(':');

        ipAddress = tokens[0];
        string portText = tokens[1];
        port = 8888;
        int.TryParse(portText, out port);
        name = tokens[2];
    }
}