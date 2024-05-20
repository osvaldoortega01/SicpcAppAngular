import { Component, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgbCarouselModule, NgbCarousel, NgbSlideEvent, NgbSlideEventSource } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [NgbCarouselModule, FormsModule,RouterModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  images = [
    'assets/slider/planning.jpg',
    'assets/slider/business.jpg',
    'assets/slider/teamwork.jpg',
    'assets/slider/working_on_table.jpg',
  ]
	paused = false;
	unpauseOnArrow = false;
	pauseOnIndicator = false;
	pauseOnHover = true;
	pauseOnFocus = true;

	@ViewChild('carousel', { static: true }) carousel: NgbCarousel = new NgbCarousel();

	togglePaused() {
		if (this.paused) {
			this.carousel.cycle();
		} else {
			this.carousel.pause();
		}
		this.paused = !this.paused;
	}

	onSlide(slideEvent: NgbSlideEvent) {
		if (
			this.unpauseOnArrow &&
			slideEvent.paused &&
			(slideEvent.source === NgbSlideEventSource.ARROW_LEFT || slideEvent.source === NgbSlideEventSource.ARROW_RIGHT)
		) {
			this.togglePaused();
		}
		if (this.pauseOnIndicator && !slideEvent.paused && slideEvent.source === NgbSlideEventSource.INDICATOR) {
			this.togglePaused();
		}
	}

}
