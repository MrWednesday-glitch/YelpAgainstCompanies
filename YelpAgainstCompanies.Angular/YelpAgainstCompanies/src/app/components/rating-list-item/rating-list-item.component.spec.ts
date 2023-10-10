import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RatingListItemComponent } from './rating-list-item.component';

describe('RatingListItemComponent', () => {
  let component: RatingListItemComponent;
  let fixture: ComponentFixture<RatingListItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RatingListItemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RatingListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
