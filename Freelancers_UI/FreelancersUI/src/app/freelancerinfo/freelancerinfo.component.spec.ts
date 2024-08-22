import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FreelancerinfoComponent } from './freelancerinfo.component';

describe('FreelancerinfoComponent', () => {
  let component: FreelancerinfoComponent;
  let fixture: ComponentFixture<FreelancerinfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FreelancerinfoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FreelancerinfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
