(function ($) {
	"use strict"

	// Preloader
	$(window).on('load', function () {
		$('#preloader-active').delay(450).fadeOut('slow');
		$('body').delay(450).css({
			'overflow': 'visible'
		});
	});


	// Mobile Menu
	var menu = $('ul#navigation');
	if (menu.length) {
		menu.slicknav({
			prependTo: ".mobile_menu",
			closedSymbol: '+',
			openedSymbol: '-'
		});
	};

	// Hero Slider
	function mainSlider() {
		var BasicSlider = $('.slider-active');
		BasicSlider.on('init', function (e, slick) {
			var $firstAnimatingElements = $('.single-slider:first-child').find('[data-animation]');
			doAnimations($firstAnimatingElements);
		});
		BasicSlider.on('beforeChange', function (e, slick, currentSlide, nextSlide) {
			var $animatingElements = $('.single-slider[data-slick-index="' + nextSlide + '"]').find('[data-animation]');
			doAnimations($animatingElements);
		});
		BasicSlider.slick({
			autoplay: false,
			autoplaySpeed: 10000,
			dots: true,
			dotsClass: "my-dots",
			fade: true,
			arrows: false,
			prevArrow: '',
			nextArrow: '',
			responsive: [{
					breakpoint: 1024,
					settings: {
						slidesToShow: 1,
						slidesToScroll: 1,
						infinite: true,
					}
				},
				{
					breakpoint: 991,
					settings: {
						slidesToShow: 1,
						slidesToScroll: 1,
						arrows: false
					}
				},
				{
					breakpoint: 767,
					settings: {
						slidesToShow: 1,
						slidesToScroll: 1,
						arrows: false
					}
				}
			]
		});

		function doAnimations(elements) {
			var animationEndEvents = 'webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend';
			elements.each(function () {
				var $this = $(this);
				var $animationDelay = $this.data('delay');
				var $animationType = 'animated ' + $this.data('animation');
				$this.css({
					'animation-delay': $animationDelay,
					'-webkit-animation-delay': $animationDelay
				});
				$this.addClass($animationType).one(animationEndEvents, function () {
					$this.removeClass($animationType);
				});
			});
		}
	}
	mainSlider();


	// Testimonial Slider
	var testimonial = $('.h1-testimonial-active');
	if (testimonial.length) {
		testimonial.slick({
			dots: false,
			infinite: true,
			speed: 1000,
			autoplay: true,
			loop: true,
			arrows: true,
			prevArrow: '<button type="button" class="slick-prev"><i class="ti-angle-left"></i></button>',
			nextArrow: '<button type="button" class="slick-next"><i class="ti-angle-right"></i></button>',
			slidesToShow: 1,
			slidesToScroll: 1,
			responsive: [{
					breakpoint: 1024,
					settings: {
						slidesToShow: 1,
						slidesToScroll: 1,
						infinite: true,
						dots: false,
						arrow: false
					}
				},
				{
					breakpoint: 600,
					settings: {
						slidesToShow: 1,
						slidesToScroll: 1,
						arrows: false
					}
				},
				{
					breakpoint: 480,
					settings: {
						slidesToShow: 1,
						slidesToScroll: 1,
						arrows: false,
					}
				}
			]
		});
	}


	// Logo Clients Carusel
	$('.logo-slider').owlCarousel({
		center: false,
		loop: true,
		stagePadding: 0,
		margin: 0,
		smartSpeed: 1000,
		autoplay: true,
		autoplayHoverPause: true,
		dots: false,
		nav: false,
		responsive: {
			400: {
				items: 1
			},
			768: {
				items: 1
			},
			992: {
				items: 1
			},
			1000: {
				items: 5
			}
		}
	});


	// Gallery
	var client_list = $('.completed-active');
	client_list.owlCarousel({
		loop: true,
		nav: false,
		dots: false,
		margin: 15,

		autoplayHoverPause: true,
		responsive: {
			0: {
				items: 1
			},
			768: {
				items: 2
			},
			992: {
				items: 2
			},
			1200: {
				items: 3
			}
		}
	});

	client_list.on('mousewheel', '.owl-stage', function (e) {
		if (e.originalEvent.wheelDelta > 0) {
			client_list.trigger('next.owl');
		} else {
			client_list.trigger('prev.owl');
		}
		e.preventDefault();
	});

	$('.owl-filter-bar').on('click', '.item', function () {
		var $item = $(this);
		var filter = $item.data('owl-filter')
		client_list.owlcarousel2_filter(filter);

		$(".owl-filter-bar a").removeClass("active")
		$(this).addClass("active");

	})


	// Nice Select
	var nice_Select = $('select');
	if (nice_Select.length) {
		nice_Select.niceSelect();
	}

	// Sticky Menu
	$(window).on('scroll', function () {
		var scroll = $(window).scrollTop();
		if (scroll < 245) {
			$(".header-sticky").removeClass("sticky-bar");
		} else {
			$(".header-sticky").addClass("sticky-bar");
		}
	});

	$(window).on('scroll', function () {
		var scroll = $(window).scrollTop();
		if (scroll < 245) {
			$(".header-sticky").removeClass("sticky");
		} else {
			$(".header-sticky").addClass("sticky");
		}
	});


	// Data Bg
	$("[data-background]").each(function () {
		$(this).css("background-image", "url(" + $(this).attr("data-background") + ")")
	});


	// Set Bg
	$('.set-bg').each(function () {
		var bg = $(this).data('setbg');
		$(this).css('background-image', 'url(' + bg + ')');
	});


	// Go To Top 
	$(window).scroll(function () {
		if ($(this).scrollTop() > 100) {
			$('#scrollUp').fadeIn();
		} else {
			$('#scrollUp').fadeOut();
		}
	});
	// scroll body to 0px on click
	$('#scrollUp').on('click', function () {
		$('body,html').animate({
			scrollTop: 0
		}, 800);
		return false;
	});


	// Counter 
	var counter = function () {

		$('.counter , .counter-2').waypoint(function (direction) {

			if (direction === 'down' && !$(this.element).hasClass('ftco-animated')) {

				var comma_separator_number_step = $.animateNumber.numberStepFactories.separator(',')
				$('.number').each(function () {
					var $this = $(this),
						num = $this.data('number');
					// console.log(num);
					$this.animateNumber({
						number: num,
						numberStep: comma_separator_number_step
					}, 3000);
				});

			}

		}, {
			offset: '95%'
		});

	}
	counter();

	var contentWayPoint = function () {
		var i = 0;
		$('.ftco-animate').waypoint(function (direction) {

			if (direction === 'down' && !$(this.element).hasClass('ftco-animated')) {

				i++;

				$(this.element).addClass('item-animate');
				setTimeout(function () {

					$('body .ftco-animate.item-animate').each(function (k) {
						var el = $(this);
						setTimeout(function () {
							var effect = el.data('animate-effect');
							if (effect === 'fadeIn') {
								el.addClass('fadeIn ftco-animated');
							} else if (effect === 'fadeInLeft') {
								el.addClass('fadeInLeft ftco-animated');
							} else if (effect === 'fadeInRight') {
								el.addClass('fadeInRight ftco-animated');
							} else {
								el.addClass('fadeInUp ftco-animated');
							}
							el.removeClass('item-animate');
						}, k * 50, 'easeInOutExpo');
					});

				}, 100);

			}

		}, {
			offset: '95%'
		});
	};
	contentWayPoint();


	// Pop Up Video
	var popUp = $('.popup-video');
	if (popUp.length) {
		popUp.magnificPopup({
			type: 'iframe'
		});
	}


	// Isotope Filter
	var $container = $('.work-gallery');
	$container.imagesLoaded().progress(function () {
		$container.isotope();
	});

	$('.filter-wrapper li a').on('click', function () {
		$(".filter-wrapper li a").removeClass("active");
		$(this).addClass("active");
		var selector = $(this).attr('data-filter');
		$container.imagesLoaded().progress(function () {
			$container.isotope({
				filter: selector,
			});
		});
		return false;
	});

})(jQuery);