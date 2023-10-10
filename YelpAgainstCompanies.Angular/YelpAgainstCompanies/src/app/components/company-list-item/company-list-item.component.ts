import { Component, Input } from '@angular/core';
import Company from 'src/app/interfaces/company';

@Component({
  selector: 'app-company-list-item',
  templateUrl: './company-list-item.component.html',
  styleUrls: ['./company-list-item.component.scss']
})

export class CompanyListItemComponent {
  @Input() company: Company | undefined;
}
