doubleMe x = x + x

doubleUs x y = doubleMe x + doubleMe y

length' xs = sum[1 | _<-xs]

sayMe :: (Integral a) => a -> String
sayMe 1 = "One!"
sayMe x = "Not in scope"

rip lst =
	let back = tail lst
	in let front = head lst
		in (lst, front:back)