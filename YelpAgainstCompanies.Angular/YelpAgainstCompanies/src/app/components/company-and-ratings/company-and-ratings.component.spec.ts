import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanyAndRatingsComponent } from './company-and-ratings.component';

describe('CompanyAndRatingsComponent', () => {
  let component: CompanyAndRatingsComponent;
  let fixture: ComponentFixture<CompanyAndRatingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CompanyAndRatingsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CompanyAndRatingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
