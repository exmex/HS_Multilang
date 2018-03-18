<?php
/*string[] s = res.Split('/');
player.id = s[1];
player.nickname = s[2];
player.expack = int.Parse(s[3]);
player.gold = int.Parse(s[4]);
player.rmb = 2000;
for(int x=5;x<s.Length;x++)
{
player.cards += s[x] + "/";
}*/
/*echo "ok";
echo "/1";
echo "/ExMex";
echo "/100";
echo "/1000";

// Card items
echo "/id1";
echo "/id2";
echo "/id3";
echo "/id4";*/

echo json_encode(array(
	"result" => 0, // 0 = ok
	"id" => 0,
	"username" => $_POST['username'],
	"expack" => 20,
	"gold" => 20000,
	"rmb" => 20000,
	"cards" => array(
		"id1",
	)
));
?>