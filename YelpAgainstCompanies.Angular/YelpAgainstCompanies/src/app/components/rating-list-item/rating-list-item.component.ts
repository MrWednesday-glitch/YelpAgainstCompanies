import { Component, Input } from '@angular/core';
import Rating from 'src/app/interfaces/rating';

@Component({
  selector: 'app-rating-list-item',
  templateUrl: './rating-list-item.component.html',
  styleUrls: ['./rating-list-item.component.scss']
})
export class RatingListItemComponent {
  @Input() rating: Rating | undefined;
}
