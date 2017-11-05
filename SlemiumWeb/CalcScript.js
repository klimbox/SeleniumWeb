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
	var res;
	switch(o)
	{
		case '+': res = a + b;
		break;
		case '-': res = a - b;
		break;
		case '*': res = a * b;
		break;
		case '/': if( b!=0 ) res = a / b;
		break;
		default: break;
	}
	return res;
}