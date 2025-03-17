import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VanillaViewComponent } from './vanilla-view.component';

describe('VanillaViewComponent', () => {
  let component: VanillaViewComponent;
  let fixture: ComponentFixture<VanillaViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VanillaViewComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VanillaViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
