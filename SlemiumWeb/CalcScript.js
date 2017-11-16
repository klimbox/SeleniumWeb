function CountFromString(inp)
{	
	var str = inp.split(' ');
	var res;
	if(str.length == 3)
	{
		var a = parseInt(str[0], 10);
		var b = parseInt(str[2], 10);
		res = Count(a, b, str[1]);
		return res;
	}
}
function Count(a, b, o)
{
    var req = "a=" + a + "&b=" + b + "&op=" + o;
    var rr = new XMLHttpRequest();
    try
    {
        rr.open('GET', 'http://localhost:9999/' + req, false);
        rr.sen(null);
        return rr.responseText;
    }
    catch (Error)
    {
        return Calc(a, b, o);
    }

}
function Calc(a, b, o)
{
	var res;
	switch(o)
	{
		case '+': res = a + b;
		break;
		case '-': res = a - b;
		break;
		case '*': res = a * b;
		break;
		case '/': res = a / b;
		break;
		default: break;
	}
	return res;
}