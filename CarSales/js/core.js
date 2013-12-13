$(function() {
	var bar1= 0;	
	var bar2= 0;
	var bar3= 0;
	
	var p =  $('#price').text().split('$');
	p = p[1].replace(',','');		
	bar1 =	parseInt(p)
	//alert(bar2)
	for(i=1;i<=4;i++){
		var p =  $('#c'+i).text().split('$');
		p = p[1].replace(',','');		
		bar2 +=	parseInt(p)
	}
	bar2 = parseInt(bar2/4);
	
	for(i=1;i<=4;i++){
		var p =  $('#d'+i).text().split('$');
		p = p[1].replace(',','');		
		bar3 +=	parseInt(p)
	}
	bar3 = parseInt(bar3/4);	
	
	aaa = parseInt((bar1/(bar1+bar2+bar3))*100);
	bbb = parseInt((bar2/(bar1+bar2+bar3))*100);
	ccc = parseInt((bar3/(bar1+bar2+bar3))*100);
	
	var by = 0;
	if((aaa+(aaa/2)) <95 && (bbb+(bbb/2)) <95 && (ccc+(ccc/2)) <95){
		by = 2;	
	}else if((aaa+(aaa/3)) <95 && (bbb+(bbb/3)) <95 && (ccc+(ccc/3)) <95){
		by = 3;		
	}else if((aaa+(aaa/4)) <95 && (bbb+(bbb/4)) <95 && (ccc+(ccc/4)) <95){
		by = 4;		
	}	
	aaa+= parseInt(aaa/by);
	bbb+= parseInt(bbb/by);
	ccc+= parseInt(ccc/by);
	var arr = [aaa,bbb,ccc];
	//alert(aaa+', '+bbb+', '+ccc);
	var i= 0;
	$('#chart li').each(function() {
		var pc = arr[i];
		pc = pc > 100 ? 100 : pc;
		if(i==0){
			$(this).children('.percent').html(bar1).formatCurrency();	
		}else if(i==1){
			$(this).children('.percent').html(bar2).formatCurrency();	
		}else if(i==2){
			$(this).children('.percent').html(bar3).formatCurrency();	
		}
		
		var ww = $(this).width();
		var len = parseInt(ww, 10) * parseInt(pc, 10) / 100;
		$(this).children('.bar').animate({ 'width' : len+'px' }, 1500);
		i++;
	});
	
	
	
	
	/*
	$('#chart li').each(function() {
		var pc = $(this).attr('title');
		pc = pc > 100 ? 100 : pc;
		$(this).children('.percent').html(pc+'%');
		var ww = $(this).width();
		var len = parseInt(ww, 10) * parseInt(pc, 10) / 100;
		$(this).children('.bar').animate({ 'width' : len+'px' }, 1500);
	});
	
	$('#form_values input').blur(function() {		
		var id = $(this).attr('id').split('_');
		var v = $(this).val();
		if (v > 100) {
			v = 100;
			$(this).val(v);			
		}
		$('#chart li:nth-child('+id[1]+')').children('.percent').html(v+'%');
		var ww = $('#chart li:first-child').width();
		var len = parseInt(ww, 10) * parseInt(v, 10) / 100;
		$('#chart li:nth-child('+id[1]+')').children('.bar').animate({ 'width' : len+'px' }, 1500);
	});
	*/

});