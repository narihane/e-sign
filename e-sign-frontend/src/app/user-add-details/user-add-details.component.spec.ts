import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserAddDetailsComponent } from './user-add-details.component';

describe('UserAddDetailsComponent', () => {
  let component: UserAddDetailsComponent;
  let fixture: ComponentFixture<UserAddDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserAddDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserAddDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
